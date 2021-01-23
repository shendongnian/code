    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
      </startup>
      <system.data>
        <DbProviderFactories>
          <remove invariant="MySql.Data.MySqlClient" />
          <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description="Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data" />
        </DbProviderFactories>
      </system.data>
      <connectionStrings>
        <add name="MyContext" connectionString="server=127.0.0.1; User Id=root; Password=password; Persist Security Info=True; database=Test;" providerName="MySql.Data.MySqlClient" />
      </connectionStrings>
    </configuration>
