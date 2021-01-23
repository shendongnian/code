    <profile defaultProvider="AspNetSqlProfileProvider" enabled="true" automaticSaveEnabled="true" >
    <providers>
    <clear />
    <add name="AspNetSqlProfileProvider"
    connectionStringName="DbConnString"
    applicationName="MyApplication"
    type="System.Web.Profile.SqlProfileProvider"/>
    </providers>
    <properties>
    <add name="PropertyName" allowAnonymous="false" type="System.Int16" />
    </properties>
    </profile>
