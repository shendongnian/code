    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="true" />
      </configSections>
      <startup useLegacyV2RuntimeActivationPolicy="true">
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0,Profile=Client" />
      </startup>
      <system.data>
        <DbProviderFactories>
          <remove invariant="System.Data.SQLite" />
          <add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite"
               type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Version=1.0.84.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
        </DbProviderFactories>
      </system.data>
      <connectionStrings>
        <add name="MySqliteContext" connectionString="Data Source=|DataDirectory|Sample.s3db" providerName="System.Data.SQLite" />
      </connectionStrings>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.SQLite.SQLiteFactory, EntityFramework">
          <parameters>
            <parameter value="v11.0" />
          </parameters>
        </defaultConnectionFactory>
      </entityFramework>
    </configuration>
