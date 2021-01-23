    <?xml version="1.0"?>
     <configuration>
      <configSections>
       <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework,Version=6.0.0.0, Culture=neutral,PublicKeyToken=b77a5c561934e089" requirePermission="false"/>
      </configSections>
       <connectionStrings>
        <add name="maconnexion" connectionString="User Id=postgres;Password=slots2013;Host=localhost;Database=DB_Ticketing;" providerName="Npgsql"/></connectionStrings>
      <startup>
      <supportedRuntime version="v4.0"sku=".NETFramework,Version=v4.0,Profile=Client"/>
      </startup>
       <entityFramework>
      <providers>
       <provider invariantName="Npgsql" type="Npgsql.NpgsqlServices,Npgsql.EntityFramework">
       </provider>
      </providers>
     <defaultConnectionFactory type="Npgsql.NpgsqlConnectionFactory,Npgsql"/>
       </entityFramework>
       <system.data>
       <DbProviderFactories>
      <remove invariant="Npgsql"></remove>
      <add name="Npgsql Data Provider" invariant="Npgsql" description="Data Provider for PostgreSQL" type="Npgsql.NpgsqlFactory, Npgsql"/>
       </DbProviderFactories>
    </system.data>
