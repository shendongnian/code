    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
      </entityFramework>
      <connectionStrings>
        <!-- -->
      </connectionStrings>
      <system.serviceModel>
        <bindings>
          <wsHttpBinding>
            <binding name="WSHttpBinding_IHotLine1" closeTimeout="00:10:00"
              openTimeout="00:10:00" receiveTimeout="00:10:00" sendTimeout="00:10:00"
              maxBufferPoolSize="2147483647" maxReceivedMessageSize="2147483647">
              <readerQuotas maxDepth="2147483647" maxStringContentLength="2147483647"
                maxArrayLength="2147483647" maxBytesPerRead="2147483647" maxNameTableCharCount="2147483647" />
              <security>
                <message clientCredentialType="UserName" />
              </security>
            </binding>
          </wsHttpBinding>
        </bindings>
        <client>
          <endpoint address="localhost:6767/blabla.svc" binding="wsHttpBinding"
            bindingConfiguration="WSHttpBinding_IHotLine1" contract="ServiceReference2.IHotLine"
            name="WSHttpBinding_IHotLine1">
            <identity>
              <certificate encodedValue="====encodedvalue===" />
            </identity>
          </endpoint>
        </client>
      </system.serviceModel>
    </configuration>
