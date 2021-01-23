    public class MyService : IMyService
    {
        public bool MyServiceFunction(string xml)
        {
            SuppliedXSD x = new SuppliedXSD();
            x.LoadXml(xml);
            // do stuff with your data.
        }
    }
