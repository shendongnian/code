    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="system.identityModel" type="System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
      </configSections>
      <appSettings>
        <add key="aspnet:UseTaskFriendlySynchronizationContext" value="true" />
        <add key="ida:FederationMetadataLocation" value="http://localhost:14060/wsFederationSTS/FederationMetadata/2007-06/FederationMetadata.xml" />
        <add key="ida:ProviderSelection" value="localSTS" />
        <add key="ida:EnforceIssuerValidation" value="false" />
      </appSettings>
      <location path="FederationMetadata">
        <system.web>
          <authorization>
            <allow users="*" />
          </authorization>
        </system.web>
      </location>
      <system.web>
        <compilation debug="true" targetFramework="4.5" />
        <httpRuntime targetFramework="4.5" />
      </system.web>
      <system.serviceModel>
        <behaviors>
          <serviceBehaviors>
            <behavior>
              <!-- To avoid disclosing metadata information, set the values below to false before deployment -->
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true" />
              <!-- To receive exception details in faults for debugging purposes, set the value below to true.  Set to false before deployment to avoid disclosing exception information -->
              <serviceDebug includeExceptionDetailInFaults="false" />
              <serviceCredentials useIdentityConfiguration="true">
                <!--Certificate added by Identity and Access Tool for Visual Studio.-->
                <serviceCertificate findValue="CN=localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectDistinguishedName" />
              </serviceCredentials>
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <protocolMapping>
          <add scheme="http" binding="ws2007FederationHttpBinding" />
          <add binding="basicHttpsBinding" scheme="https" />
        </protocolMapping>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
        <bindings>
          <ws2007FederationHttpBinding>
            <binding name="">
              <security mode="Message">
                <message>
                  <issuerMetadata address="http://localhost:14060/wsTrustSTS/mex" />
                </message>
              </security>
            </binding>
          </ws2007FederationHttpBinding>
        </bindings>
      </system.serviceModel>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests="true" />
        <!--
            To browse web app root directory during debugging, set the value below to true.
            Set to false before deployment to avoid disclosing web app folder information.
          -->
        <directoryBrowse enabled="true" />
      </system.webServer>
      <system.identityModel>
        <identityConfiguration>
          <audienceUris>
            <add value="http://localhost:49768/Service1.svc" />
          </audienceUris>
          <!--Commented by Identity and Access VS Package-->
          <!--<issuerNameRegistry type="System.IdentityModel.Tokens.ValidatingIssuerNameRegistry, System.IdentityModel.Tokens.ValidatingIssuerNameRegistry"><authority name="LocalSTS"><keys><add thumbprint="9B74CB2F320F7AAFC156E1252270B1DC01EF40D0" /></keys><validIssuers><add name="LocalSTS" /></validIssuers></authority></issuerNameRegistry>-->
          <!--certificationValidationMode set to "None" by the the Identity and Access Tool for Visual Studio. For development purposes.-->
          <certificateValidation certificateValidationMode="None" />
          <issuerNameRegistry type="System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
            <trustedIssuers>
              <add thumbprint="9B74CB2F320F7AAFC156E1252270B1DC01EF40D0" name="LocalSTS" />
            </trustedIssuers>
          </issuerNameRegistry>
        </identityConfiguration>
      </system.identityModel>
    </configuration>
