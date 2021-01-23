    <?xml version="1.0" encoding="utf-8"?>
    
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
      </configSections>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.1" />
      </startup>
     
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <!--<provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />-->
          <provider invariantName="System.Data.SQLite.EF6" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />
        </providers>
      </entityFramework>
      
      <system.data>
        <!--
            NOTE: The extra "remove" element below is to prevent the design-time
                  support components within EF6 from selecting the legacy ADO.NET
                  provider for SQLite (i.e. the one without any EF6 support).  It
                  appears to only consider the first ADO.NET provider in the list
                  within the resulting "app.config" or "web.config" file.
        -->
        <DbProviderFactories>
          <remove invariant="System.Data.SQLite" />
          <add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Version=1.0.94.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
    
          <remove invariant="System.Data.SQLite.EF6" />
          <add name="SQLite Data Provider (Entity Framework 6)" invariant="System.Data.SQLite.EF6" description=".NET Framework Data Provider for SQLite (Entity Framework 6)" type="System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6" />
        </DbProviderFactories>
      </system.data>
      <connectionStrings>
        <add name="VelocityDBEntities" connectionString="metadata=res://*/AppData.Model1.csdl|res://*/AppData.Model1.ssdl|res://*/AppData.Model1.msl;provider=System.Data.SQLite.EF6;provider connection string=&quot;data source=F:\VelocityPOS\VelocityDB.sqlite&quot;" providerName="System.Data.EntityClient" />
      </connectionStrings>
    </configuration>
