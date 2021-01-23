      <system.serviceModel>
        <services>
          <service name="Your.Namespace.Path.To.Your.Service" behaviorConfiguration="SecureBehavior">
            <endpoint binding="wsHttpBinding" bindingConfiguration="SecureBinding" contract="NLog.LogReceiverService.ILogReceiverServer"/>
            <endpoint binding="mexHttpBinding" contract="IMetadataExchange" address="mex"/>
            <host>
              <baseAddresses>
                <add baseAddress="https://your_secure_domain.com/servicePath"/>
              </baseAddresses>
            </host>
          </service>
        </services>
        <behaviors>
          <serviceBehaviors>
            <behavior name="SecureBehavior">
              <serviceDebug includeExceptionDetailInFaults="true"/>
              <serviceMetadata httpsGetEnabled="true"/>
              <serviceCredentials>
                <!--You must set your certificate configuration to make this example work-->
                <serviceCertificate findValue="0726d1969a5c8564e0636f9eec83f92e" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySerialNumber"/>
                <userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="AssamblyOf.YourCustom.UsernameValidator.UsernameValidator, AssamblyOf.YourCustom.UsernameValidator"/>
              </serviceCredentials>
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <bindings>
          <wsHttpBinding>
            <binding name="SecureBinding" closeTimeout="00:00:20" openTimeout="00:00:20" receiveTimeout="00:00:20" sendTimeout="00:00:20">
              <security mode="TransportWithMessageCredential">
                <message clientCredentialType="UserName"/>
                <transport clientCredentialType="None"/>
              </security>
            </binding>
          </wsHttpBinding>
        </bindings>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" />
      </system.serviceModel>
