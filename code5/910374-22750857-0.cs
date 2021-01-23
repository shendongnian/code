    using (YourDbContext db = new YourDbContext(){///}
    <configuration>
        <configSections>
            <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        </configSections>
        <connectionStrings>
            <add name="NorthwindEntitiesLib" connectionString="metadata=res://*/App_Code.Model.csdl|res://*/App_Code.Model.ssdl|res://*/App_Code.Model.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=KM;initial catalog=Northwind;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
        </connectionStrings>
        <system.web>
            <compilation debug="true" targetFramework="4.5">
                <assemblies>
                    <add assembly="System.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
                    <add assembly="System.Data.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
                    <add assembly="System.Data.Entity.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
                </assemblies>
               <buildProviders>
                  <add extension=".edmx" type="System.Data.Entity.Design.AspNet.EntityDesignerBuildProvider" />
               </buildProviders>
               </compilation>
                   <httpRuntime targetFramework="4.5" />
               <profile defaultProvider="DefaultProfileProvider">
                    <providers>
                        <add name="DefaultProfileProvider" type="System.Web.Providers.DefaultProfileProvider, System.Web.Providers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" connectionStringName="DefaultConnection" applicationName="/" />
                    </providers>
               </profile>
         </system.web>
         <entityFramework>
            <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
         </entityFramework>
    </configuration>
