      <connectionStrings>
        <add name="NAMEOFYOURCONTEXT" providerName="MySql.Data.MySqlClient" connectionString="Server=localhost;Database=abc;Uid=root;Pwd='';" />
      </connectionStrings>
      <entityFramework>
        <defaultConnectionFactory type="MySql.Data.Entity.MySqlConnectionFactory, MySql.Data.Entity.EF6"></defaultConnectionFactory>
        <providers>
          <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6"></provider>
        </providers>
      </entityFramework>
