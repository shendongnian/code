    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Management.Automation;
    using System.Collections.ObjectModel;
    using System.Management.Automation.Runspaces;
    using System.Security;
    using System.Management.Automation.Remoting;
    namespace ExchangeConnection
    {
    class ExchangeShell
    {
        //Credentials
        const string userName = "username";
        const string password = "password";
        private PowerShell InitializePS()
        {
            
            PSCredential credential = new PSCredential(userName, SecurePassword());
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri("exchange server url/Powershell"), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", credential);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
            connectionInfo.MaximumConnectionRedirectionCount = 5;
            connectionInfo.SkipCNCheck = true;
            connectionInfo.OpenTimeout = 999999;
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            runspace.Open();
            PowerShell powershell = PowerShell.Create();
            powershell.Runspace = runspace;
            return powershell;
                
        }
        private SecureString SecurePassword()
        {
            System.Security.SecureString securePassword = new System.Security.SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            return securePassword;
        }
        public void GetMessageTrackingLog(string sender)
        {
            PowerShell ps = InitializePS();
            ps.AddCommand("Get-MessageTrackingLog");
            ps.AddParameter("Start", DateTime.Now.AddHours(-24).ToString());
            ps.AddParameter("ResultSize", "Unlimited");
            ps.AddParameter("Sender", sender);
            ps.AddParameter("EventId", "SEND");
            Collection<PSObject> results = ps.Invoke();
            Console.WriteLine("|----Sender----|----Recipients----|----DateTime----|----Subject----|");
            foreach (var r in results)
            {
                string senders = r.Properties["Sender"].Value.ToString();
                string recipients = r.Properties["Recipients"].Value.ToString();
                string timestamp = r.Properties["Timestamp"].Value.ToString();
                string subject = r.Properties["MessageSubject"].Value.ToString();
                string eventID = r.Properties["EventID"].Value.ToString();
                string messageInfo = r.Properties["MessageInfo"].Value.ToString();
                Console.WriteLine("{0}|{1}|{2}|{3}", sender, recipients, timestamp, subject);
            }
            ps.Dispose();
            ps.Runspace.Dispose();
            
        }
    }
    }
