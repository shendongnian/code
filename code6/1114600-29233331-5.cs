      <system.serviceModel>
        <bindings>
          <basicHttpBinding>
            <binding name="securebasicHttpBinding" maxReceivedMessageSize="104857600">
              <security mode="Message">
                <message clientCredentialType="Certificate" />
              </security>
            </binding>
          </basicHttpBinding>
        </bindings>
    
        <services>
          <service behaviorConfiguration="secureBehaviour" name="AccountService">
            <endpoint address="" binding="basicHttpBinding" bindingConfiguration="securebasicHttpBinding"
              contract="IAccountService" />
          </service>
          <service behaviorConfiguration="secureBehaviour" name="PortalService">
            <endpoint address="" binding="basicHttpBinding" bindingConfiguration="securebasicHttpBinding"
              contract="IPortalService" />
          </service>
        </services>
    
        <behaviors>
          <serviceBehaviors>
            <behavior name="secureBehaviour">
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="false"/>
              <serviceCredentials>
                <serviceCertificate ...something goes here... />
                <clientCertificate>
                  <authentication certificateValidationMode="Custom" customCertificateValidatorType="Services.Validators.CertificateValidator, Services" />
                </clientCertificate>
              </serviceCredentials>
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <protocolMapping>
          <add binding="basicHttpsBinding" scheme="https" />
        </protocolMapping>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
      </system.serviceModel>
