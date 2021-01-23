        public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
            using (var client = ScriptMain.CreateWebServiceInstance())
            {
                Row.BankIBAN = client.BBANtoIBANandBIC(Row.AccountNum_IsNull ? "" : Row.AccountNum).ToString();
            }
        }
    
        internal static SC_MYSCRIPTCOMPONENT.ServiceReference1.BANBICSoapClient CreateWebServiceInstance()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            // I think most (or all) of these are defaults--I just copied them from app.config:
            binding.Security.Mode = BasicHttpSecurityMode.None;
            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
            binding.AllowCookies = false;
            binding.BypassProxyOnLocal = true;
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.MessageEncoding = WSMessageEncoding.Text;
            binding.TextEncoding = System.Text.Encoding.UTF8;
            binding.TransferMode = TransferMode.Buffered;
            binding.UseDefaultWebProxy = true;
            return new SC_MYSCRIPTCOMPONENT.ServiceReference1.BANBICSoapClient(binding, new EndpointAddress("http://www.ibanbic.be/IBANBIC.asmx"));
        }
