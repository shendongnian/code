        <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        <section name="electra.common.configuration.electraConfiguration" type="Electra.Common.Configuration.ElectraConfiguration, Electra.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" allowDefinition="Everywhere" allowExeDefinition="MachineToApplication" restartOnExternalChanges="true" />
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
      </configSections>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.1" />
      </startup>
      <connectionStrings>
        <add name="DBContext_Server" 
    		connectionString="server=sunset\sql2012;Integrated Security=SSPI;database=Electra;Pooling=true;max pool size=1000;min pool size=5;Connection Lifetime=30;connection timeout=15" 
    		providerName="System.Data.SqlClient" />
        <add name="DBContext_ElectraPOS" 
    		connectionString="Data Source=D:\Electra\ElectraWeb\PosEngine.Repository\ElectraPOS.db" 
    		providerName="System.Data.SQLite.EF6" />
      </connectionStrings>
    	<system.data>
    		<DbProviderFactories>
    			<remove invariant="System.Data.SQLite" />
    			<add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Version=1.0.91.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
    			<remove invariant="System.Data.SQLite.EF6" />
    			<add name="SQLite Data Provider (Entity Framework 6)" invariant="System.Data.SQLite.EF6" description=".Net Framework Data Provider for SQLite (Entity Framework 6)" type="System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6, Version=1.0.91.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
    		</DbProviderFactories>
    	</system.data>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    		<provider invariantName="System.Data.SQLite.EF6" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6, Version=1.0.91.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
    		<provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6, Version=1.0.91.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
        </providers>
      </entityFramework>
      <electra.common.configuration.electraConfiguration>
        <logging>
          <levels info="true" warning="true" error="true" debug="true" />
        </logging>
      </electra.common.configuration.electraConfiguration>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <assemblyIdentity name="System.Web.Http" publicKeyToken="31bf3856ad364e35" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="5.0.0.0" />
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="Microsoft.Owin" publicKeyToken="31bf3856ad364e35" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-2.1.0.0" newVersion="2.1.0.0" />
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="System.Net.Http.Formatting" publicKeyToken="31bf3856ad364e35" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="5.0.0.0" />
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="Microsoft.Owin.Security" publicKeyToken="31bf3856ad364e35" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-2.0.2.0" newVersion="2.0.2.0" />
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
    </configuration>
