	<entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlCeConnectionFactory, EntityFramework">
      <parameters>    
      <parameter value="Data Source=.\someserver; Integrated Security=False; User ID=myuser;Password=mypass; MultipleActiveResultSets=True" />
      </parameters>
    </defaultConnectionFactory>
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  	</entityFramework>
	<clear />
    <remove name="DefaultConnection" />
   
  	<add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=.\someserver;database=mydb;Integrated Security = False; User ID=myuser; Password=mypass;"/>
