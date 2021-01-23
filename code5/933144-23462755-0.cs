    public class Program
    {
        static void Main(string[] args)
        {
            SapConnection con = new SapConnection();
            RfcDestinationManager.RegisterDestinationConfiguration(con);
            RfcDestination dest = RfcDestinationManager.GetDestination("NSP");
            RfcRepository repo = dest.Repository;
            IRfcFunction fReadTable = repo.CreateFunction("ZSOMA");
            fReadTable.SetValue("I_NRO1", 1);
            fReadTable.SetValue("I_NRO2", 2);
            fReadTable.Invoke(dest);
            var result = fReadTable.GetValue("E_RESULT");
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
    public class SapConnection : IDestinationConfiguration
    {
        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters conf = new RfcConfigParameters();
            if (destinationName == "NSP")
            {
                conf.Add(RfcConfigParameters.AppServerHost, "sap-vm");
                conf.Add(RfcConfigParameters.SystemNumber, "00");
                conf.Add(RfcConfigParameters.SystemID, "xxx");
                conf.Add(RfcConfigParameters.User, "yourusername");
                conf.Add(RfcConfigParameters.Password, "yourpassword");
                conf.Add(RfcConfigParameters.Client, "001");
            }
            return conf;
        }
        public bool ChangeEventsSupported()
        {
            return true;
        }
        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;
    }
