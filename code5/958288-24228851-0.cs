       <?xml version="1.0" encoding="utf-8"?>
        <configuration>
          <configSections>
            <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
          </configSections>  
          <startup>
            <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
          </startup>
          <system.serviceModel>
            <bindings>
              <basicHttpBinding>
                <binding name="OrdersEndPoint" />
              </basicHttpBinding>
            </bindings>
            <client>
              <endpoint address="http://localhost:8080/OrdersHelper" binding="basicHttpBinding" bindingConfiguration="OrdersEndPoint" contract="ServiceReference.IOrdersHelper" name="OrdersEndPoint" />
            </client>
          </system.serviceModel>
          <entityFramework>
            <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
            <providers>
              <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
            </providers>
          </entityFramework>
        
        
        <connectionStrings>
            <add name="northwindEntities" connectionString="metadata=res://*/NorthwindModel.csdl|res://*/NorthwindModel.ssdl|res://*/NorthwindModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=northwind;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
          </connectionStrings>
        
        
        </configuration>
