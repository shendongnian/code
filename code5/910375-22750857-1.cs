    <configuration>
        <configSections>
            <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        </configSections>
        <connectionStrings>
            <add name="NorthwindEntitiesLib" connectionString="metadata=res://*/App_Code.Model.csdl|res://*/App_Code.Model.ssdl|res://*/App_Code.Model.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=KM;initial catalog=Northwind;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
        </connectionStrings>
         <entityFramework>
            <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
         </entityFramework>
    </configuration>
