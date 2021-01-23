    namespace SampleService   // this is service 
    {
        public class Service1 : IService1
        {
            public string GetMessage()
            {
                return "Hello World";
            }
            public string GetAddress()
            {
                return "123 New Street, New York, NY 12345";
            }
        }
    }
    
    
    protected void Page_Load(object sender, EventArgs e)  //  calling the service 
    {
        using (ServiceClient<IService1> ServiceClient = 
               new ServiceClient<IService1>("BasicHttpBinding_IService1"))
        {
            this.Label1.Text = ServiceClient.Proxy.GetMessage();
            //once you have done the build inteli sense 
                //will automatically gets the new function
            this.Label2.Text = ServiceClient.Proxy.GetAddress();
        }
    }
