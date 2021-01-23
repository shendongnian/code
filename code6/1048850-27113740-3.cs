    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="entityFramework" 
                 type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.1.1, Culture=neutral, PublicKeyToken=b77a5c561934e089" 
                 requirePermission="false" />
      </configSections>
      <!-- <connectionStrings configSource="../Zk/ConnectionStrings.config" /> -->
      <connectionStrings>
        <clear />
        <add name="ZkTestDatabaseConnection" 
             connectionString="Server=localhost;Port=5432;Database=ZkTestDatabase;User Id=zktest;Password=broccoli;CommandTimeout=20;" 
             providerName="Npgsql" />
      </connectionStrings>
      <system.data>
        <DbProviderFactories>
          <add name="Npgsql Data Provider" 
               invariant="Npgsql" 
               description="Data Provider for PostgreSQL" 
               type="Npgsql.NpgsqlFactory, Npgsql" />
        </DbProviderFactories>
      </system.data>
      <entityFramework>
        <defaultConnectionFactory type="Npgsql.NpgsqlFactory, Npgsql" />
        <providers>
          <provider invariantName="Npgsql" 
                    type="Npgsql.NpgsqlServices, Npgsql.EntityFramework" />
        </providers>
      </entityFramework>
    </configuration> 
