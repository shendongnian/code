    <entityFramework>
      <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
      <providers>
        <provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6, Version=1.0.94.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
        <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        <!--<provider invariantName="System.Data.SQLite.EF6" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />-->
      </providers>
    </entityFramework>
    <connectionStrings>
      <add name="SettingContext" connectionString="Data Source=setting.db" providerName="System.Data.SQLite" />
      
