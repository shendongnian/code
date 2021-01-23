    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
      </configSections>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
      </startup>
      <connectionStrings>
        <add name="prismatic_dbEntities" connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;server=localhost;user id=pmuser;password=pmuser;persist security info=True;database=prismatic_db&quot;" providerName="MySql.Data.MySqlClient" />
        <add name="prismatic_dbPrivileges" connectionString="metadata=res://*/PMConfigPrivilegesModel.csdl|res://*/PMConfigPrivilegesModel.ssdl|res://*/PMConfigPrivilegesModel.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;server=localhost;user id=pmuser;password=pmuser;persist security info=True;database=prismatic_db&quot;" providerName="MySql.Data.MySqlClient" />
      </connectionStrings>
      <system.data>
        <DbProviderFactories>
          <remove invariant="MySql.Data.MySqlClient" />
        <add name="MySQL Data Provider"
           invariant="MySql.Data.MySqlClient"
           description=".Net Framework Data Provider for MySQL"
           type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, PublicKeyToken=c5687fc88969c44d" />
        </DbProviderFactories>
      </system.data>
  
      <entityFramework>
         <providers>
          <provider invariantName="MySql.Data.MySqlClient"
                type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity" />
        </providers>
        <defaultConnectionFactory type="MySql.Data.Entity.MySqlConnectionFactory, MySql.Data.Entity">
          <parameters>
            <parameter value="v11.0" />
          </parameters>      
        </defaultConnectionFactory>
    
      </entityFramework>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
           <dependentAssembly>
            <assemblyIdentity name="EntityFramework" publicKeyToken="b77a5c561934e089" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-6.0.0.0" newVersion="6.0.0.0" />
           </dependentAssembly>
        </assemblyBinding>
      </runtime>
    </configuration>
