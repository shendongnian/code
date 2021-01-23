      <configSections>
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
    
      <connectionStrings>
       <add name="YourModelNameHere" connectionString="metadata=res://*/RCMarketModel.csdl|res://*/YourModelNameHere.ssdl|res://*/YourModelNameHere.msl;provider=System.Data.SqlClient;provider connection string=&quot;Server=Your Server Name;Database=Your Database Name;Integrated Security=SSPI;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
      </connectionStrings>
    
    
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="v11.0" />
          </parameters>
        </defaultConnectionFactory>
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
      </entityFramework>
