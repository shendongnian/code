    <system.web>
        <roleManager>
            <providers>
                <clear/>
                <add name="AspNetSqlRoleProvider" connectionStringName="<your connection string name here>" applicationName="/" type="System.Web.Security.SqlRoleProvider, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
            </providers>
        </roleManager>
    </system.web>
