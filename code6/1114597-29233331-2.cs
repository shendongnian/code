      <system.serviceModel>
        <bindings>
          <basicHttpBinding>
            <binding name="securebasicHttpBinding" maxReceivedMessageSize="104857600">
              <security mode="Transport">
                <message clientCredentialType="Certificate" />
              </security>
            </binding>
          </basicHttpBinding>
        </bindings>
    
        <services>
          <service behaviorConfiguration="" name="AccountService">
            <endpoint address="" binding="basicHttpBinding" bindingConfiguration="securebasicHttpBinding"
              contract="IAccountService" />
          </service>
          <service behaviorConfiguration="" name="PortalService">
            <endpoint address="" binding="basicHttpBinding" bindingConfiguration="securebasicHttpBinding"
              contract="IPortalService" />
          </service>
        </services>
    
        <behaviors>
          <serviceBehaviors>
            <behavior>
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="false"/>
              <serviceCredentials>
                <clientCertificate>
                  <authentication certificateValidationMode="Custom" customCertificateValidatorType="Services.Validators.CertificateValidator, Services" />
                </clientCertificate>
              </serviceCredentials>
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <protocolMapping>
          <add binding="basicHttpsBinding" scheme="https" />
          <add binding="basicHttpBinding" scheme="https" bindingConfiguration="securebasicHttpBinding"/>
        </protocolMapping>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
      </system.serviceModel>
