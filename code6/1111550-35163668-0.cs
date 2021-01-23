    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
      </startup>
    
      <entityFramework>
        <providers>
          <provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6"/>
        </providers>
      </entityFramework>
    
      <connectionStrings>
        <!-- use AppDomain.SetData to set the DataDirectory -->
        <add name="MapDbConnectionStr" connectionString="Data Source=|DataDirectory|MapDb.sqlite" providerName="System.Data.SQLite" />
      </connectionStrings>
    
      <system.data>
        <DbProviderFactories>
          <remove invariant="System.Data.SQLite.EF6" />
          <add name="SQLite Data Provider" invariant="System.Data.SQLite" description="Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />
        </DbProviderFactories>
      </system.data>
      
      
      
    </configuration>
