      using (System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(SERVICETYPE), new Uri[] { }))
 
     <services>
          <service name="SERVICETYPE" behaviorConfiguration="serviceBehavior">
            <host>
              <baseAddresses>
                <add baseAddress="http://localhost:8000"/>
              </baseAddresses>
      </services>
    
     <endpoint address="/END" binding="basicHttpBinding" bindingConfiguration="basicHttpBinding" contract="YOUR INTERFACE"/>
