    <connectionStrings>
        <add name="MyDB" providerName="MySql.Data.MySqlClient" connectionString="Data Source=localhost; port=3306; Initial Catalog=mydb; uid=myuser; pwd=mypass;" />
      </connectionStrings>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
          <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6, Version=6.8.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d"></provider>
        </providers>
      </entityFramework>
