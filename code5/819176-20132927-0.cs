        <roleManager enabled="true">
            <providers>
                <clear />
                <add connectionStringName="ApplicationServices" name="AspNetSqlRoleProvider" type="System.Web.Security.SqlRoleProvider" applicationName="/" />
            </providers>
        </roleManager>
