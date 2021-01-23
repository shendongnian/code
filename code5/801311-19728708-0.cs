      <roleManager enabled="true" defaultProvider="AspNetSqlRoleProvider">
          <providers>
            <clear />
            <add name="AspNetSqlRoleProvider" connectionStringName="DefaultConnection" applicationName="/" type="System.Web.Security.SqlRoleProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
          </providers>
        </roleManager>
