        private static void RunService()
        {
          using (WebServiceHost host = new WebServiceHost(typeof(Service1)))
          {
            host.Open();
            Console.WriteLine("service started");
            Console.ReadLine();
          }
        }
    
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
