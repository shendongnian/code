    // program.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.ServiceModel.Description; 
    using ConsoleAJAXWCF;    
    
    namespace GettingStartedHost
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                // Step 1 Add a service endpoint.
                using (WebServiceHost selfHost = new WebServiceHost(typeof(Service1)))
                {
                    try
                    {
                       // Step 2 Start the service.
                       selfHost.Open();
                       Console.WriteLine("The service is ready.");
                       Console.WriteLine("Press <ENTER> to terminate service.");
                       Console.WriteLine();
                       Console.ReadLine();
    
                       // Close the ServiceHostBase to shutdown the service.
                       selfHost.Close();
                    }
                    catch (CommunicationException ce)
                    {
                        Console.WriteLine("An exception occurred: {0}", ce.Message);
                        selfHost.Abort();
                    }                
                }            
            }
        }
    }
        // WCF Configuration    
       <endpointBehaviors>
          <behavior name="AJAXEndpoint" >
           <webHttp/>
           </behavior>
         </endpointBehaviors>
        </behaviors>
        <services>
          <service name="ConsoleAJAXWCF.Service1">
            <endpoint 
             behaviorConfiguration="AJAXEndpoint" 
             address="" binding="webHttpBinding" contract="ConsoleAJAXWCF.IService1">
              <identity>
                <dns value="localhost"/>
              </identity>
            </endpoint>
            <host>
              <baseAddresses>
                <add baseAddress="http://localhost:52768/Service1/"/>
              </baseAddresses>
            </host>
          </service>
        </services>
