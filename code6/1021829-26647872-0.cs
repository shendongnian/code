    <service name="System.ServiceModel.Security.WSTrustServiceContract" behaviorConfiguration="ServiceBehavior">
            <endpoint address="IWSTrust13" binding="ws2007HttpBinding" contract="System.ServiceModel.Security.IWSTrust13AsyncContract" bindingConfiguration="ws2007HttpBindingConfiguration">
              <identity>
                <userPrincipalName value="yourUpn" />
                
              </identity>
            </endpoint>
    <service/>
