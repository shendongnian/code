    /// <summary>
    /// This class is used to connect to either an remote or the local exchange powershell and allows you to execute several exchange cmdlets easiely
    /// </summary>
    public class ExchangeShell : IDisposable
    {
        /// <summary>
        /// registry key to verify the installed exchange version, see <see cref="verifyExchangeVersion"/> method for more info
        /// </summary>
        private string EXCHANGE_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{4934D1EA-BE46-48B1-8847-F1AF20E892C1}";
        private ExchangeVersionEnum m_ExchangeVersion;
        /// <summary>
        /// getter to receive the current exchange version (local host only)
        /// </summary>
        public ExchangeVersionEnum ExchangeVersion { get { return m_ExchangeVersion; } }
        public enum ExchangeVersionEnum {
            Unknown = 0,
            v2010 = 1,
            v2013 = 2,
        }
        public string Host { get; private set; }
        /// <summary>
        /// stores the powershell runspaces for either local or any other remote connection
        /// </summary>
        private Dictionary<string, Runspace> m_runspaces = new Dictionary<string, Runspace>();
        /// <summary>
        /// get the current runspace being used for the cmdlets - only for internal purposes
        /// </summary>
        private Runspace currentRunspace { 
            get
            {
                if (m_runspaces.ContainsKey(this.Host))
                    return m_runspaces[this.Host];
                else
                    throw new Exception("No Runspace found for host '" + this.Host + "'. Use SetRemoteHost first");
            } 
        }
        /// <summary>
        /// Call the constructor to either open a local exchange shell or force open the local shell as remote connection (primary used to bypass "Microsoft.Exchange.Net" assembly load failures)
        /// </summary>
        /// <param name="forceRemoteShell"></param>
        public ExchangeShell(bool forceRemoteShell = false)
        {
            if (!forceRemoteShell)
            {
                this.m_ExchangeVersion = this.verifyExchangeVersion();
                if (this.m_ExchangeVersion == ExchangeVersionEnum.Unknown) throw new Exception("Unable to verify Exchange version");
                this.SetLocalHost();
            }
            else
            {
                // Use empty hostname to connect to localhost via http://computername.domain/[...]
                this.SetRemoteHost("");
            }
        }
        /// <summary>
        /// Constructor to open a remote exchange shell
        /// TODO: display authentication prompt for different login credentials
        /// </summary>
        /// <param name="hostName">host of the remote powershell</param>
        /// <param name="authenticationPrompt">not yet implemented</param>
        public ExchangeShell(string hostName, bool authenticationPrompt = false)
        {
            // TODO: Implement prompt for authenication different then default
            this.SetRemoteHost(hostName);
        }
        /// <summary>
        /// private function to verify the exchange version (local only)
        /// </summary>
        /// <returns></returns>
        private ExchangeVersionEnum verifyExchangeVersion()
        {
            var hklm = Microsoft.Win32.Registry.LocalMachine;
            var exchangeInstall = hklm.OpenSubKey(EXCHANGE_KEY);
            if (exchangeInstall != null)
            {
                var exchangeVersionKey = exchangeInstall.GetValue("DisplayVersion").ToString();
                if (exchangeVersionKey.StartsWith("14."))
                    return ExchangeVersionEnum.v2010;
                else if (exchangeVersionKey.StartsWith("15."))
                    return ExchangeVersionEnum.v2013;
            }
            return ExchangeVersionEnum.Unknown;
        }
        /// <summary>
        /// set the current runspace to local.
        /// Every command will be executed on the local machine
        /// </summary>
        public void SetLocalHost()
        {
            if (!this.m_runspaces.ContainsKey("localhost"))
            {
                RunspaceConfiguration rc = RunspaceConfiguration.Create();
                PSSnapInException psSnapInException = null;
                switch (this.m_ExchangeVersion)
                {
                    case ExchangeVersionEnum.v2010:
                        rc.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out psSnapInException);
                        break;
                    case ExchangeVersionEnum.v2013:
                        rc.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.SnapIn", out psSnapInException);
                        break;
                }
                if (psSnapInException != null)
                    throw psSnapInException;
                var runspace = RunspaceFactory.CreateRunspace(rc);
                runspace.Open();
                this.m_runspaces.Add("localhost", runspace);
            }
            this.Host = "localhost";
        }
        /// <summary>
        /// Setup a runspace for a remote host
        /// After calling this method, currentRunspace is being used to execute the commands
        /// </summary>
        /// <param name="hostName"></param>
        public void SetRemoteHost(string hostName = null)
        {
            if (String.IsNullOrEmpty(hostName))
                hostName = Environment.MachineName + "." + Environment.UserDomainName + ".local";
            hostName = hostName.ToLower();
            if (!this.m_runspaces.ContainsKey(hostName))
            {
                WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri("http://" + hostName + "/PowerShell/"), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", PSCredential.Empty);
                connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default;
                var runspace = RunspaceFactory.CreateRunspace(connectionInfo);
                // THIS CAUSES AN ERROR WHEN USING IT IN INSTALLER
                runspace.Open();
                this.m_runspaces.Add(hostName, runspace);
            }
            this.Host = hostName;
        }
        /// <summary>
        /// Get Transport agent info
        /// </summary>
        /// <param name="Name">name of the transport agent</param>
        /// <returns></returns>
        public PSObject GetAgentInfo(string Name)
        {
            PSObject result = null;
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = this.currentRunspace;
                ps.AddCommand("Get-TransportAgent");
                ps.AddParameter("Identity", Name);
                var res = ps.Invoke();
                if (res != null && res.Count > 0)
                    result = res[0];
            }
            return result;
        }
        /// <summary>
        /// get a list of exchange server available in the environment
        /// </summary>
        /// <returns>collection of powershell objects containing of all available exchange server</returns>
        public ICollection<PSObject> GetExchangeServer()
        {
            ICollection<PSObject> result;
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = this.currentRunspace;
                ps.AddCommand("Get-ExchangeServer");
                result = ps.Invoke();
            }
            return result;
        }
        /// <summary>
        /// Install a transport agent
        /// </summary>
        /// <param name="Name">name of the transportagent</param>
        /// <param name="AgentFactory">factory name of the transport agent</param>
        /// <param name="AssemblyPath">file path of the transport agent assembly</param>
        /// <param name="enable">if true, enable it after successfully installed</param>
        /// <returns>if true everything went ok, elsewise false</returns>
        public bool InstallAgent(string Name, string AgentFactory, string AssemblyPath, bool enable = false)
        {
            bool success = false;
            if (!System.IO.File.Exists(AssemblyPath))
                throw new Exception("Assembly '"+AssemblyPath+"' for TransportAgent '"+ Name +"' not found");
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = this.currentRunspace;
                ps.AddCommand("Install-TransportAgent");
                ps.AddParameter("Name", Name);
                ps.AddParameter("TransportAgentFactory", AgentFactory);
                ps.AddParameter("AssemblyPath", AssemblyPath);
                var result = ps.Invoke();
                if (result.Count > 0)
                {
                    if (enable)
                        success = this.EnableAgent(Name);
                    else
                        success = true;
                }
            }
            return success;
        }
        /// <summary>
        /// Enable a transport agent
        /// </summary>
        /// <param name="Name">name of the transport agent</param>
        /// <returns>if true everything went ok, elsewise false</returns>
        public bool EnableAgent(string Name){
            bool success = false;
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = this.currentRunspace;
                ps.AddCommand("Enable-TransportAgent");
                ps.AddParameter("Identity", Name);
                var result = ps.Invoke();
                if (result.Count <= 0) success = true;
            }
            return success;
        }
        /// <summary>
        /// removes a transport agent
        /// </summary>
        /// <param name="Name">name of the transport agent</param>
        /// <returns>if true everything went ok, elsewise false</returns>
        public bool UninstallAgent(string Name)
        {
            bool success = false;
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = this.currentRunspace;
                ps.AddCommand("Uninstall-TransportAgent");
                ps.AddParameter("Identity", Name);
                ps.AddParameter("Confirm", false);
                var result = ps.Invoke();
                if (result.Count <= 0)success = true;
            }
            return success;
        }
        /// <summary>
        /// restart exchange transport agent service
        /// A RESTART OF THIS SERVICE REQUIRED WHEN INSTALLING A NEW AGENT
        /// </summary>
        /// <returns></returns>
        public bool RestartTransportService()
        {
            bool success = false;
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = this.currentRunspace;
                ps.AddCommand("Restart-Service");
                ps.AddParameter("Name", "MSExchangeTransport");
                var result = ps.Invoke();
                if (result.Count <= 0) success = true;
            }
            return success;
        }
        public void Dispose()
        {
            if (this.m_runspaces.Count > 0)
            {
                foreach (var rs in this.m_runspaces.Values)
                {
                    rs.Close();
                }
                this.m_runspaces.Clear();
            }
        }
    }
