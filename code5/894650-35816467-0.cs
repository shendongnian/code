	<connectionStrings>
		<add name="PrimaryDatabase" providerName="MySql.Data.MySqlClient"
			connectionString="server=localhost;port=3306;database=mydatabase;uid=root;password=root"/>
	</connectionStrings>
	<entityFramework  codeConfigurationType="MySql.Data.Entity.MySqlEFConfiguration, MySql.Data.Entity.EF6">
		<defaultConnectionFactory type="MySql.Data.Entity.MySqlConnectionFactory, MySql.Data.Entity.EF6" />
		<providers>
		  <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6, Version=6.9.8.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d"/>
		</providers>
	</entityFramework>
	<system.data>
		<DbProviderFactories>
		  <remove invariant="MySql.Data.MySqlClient" />
		  <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.9.8.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
		</DbProviderFactories>
	</system.data>
