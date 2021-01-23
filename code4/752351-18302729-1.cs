    <profile inherits="ProfileNamespace.ProfileManager" defaultProvider="AspNetSqlProfileProvider" enabled="true">
    <providers>
    <clear />
    <add name="AspNetSqlProfileProvider" connectionStringName="ApplicationServices" applicationName="/" type="System.Web.Profile.SqlProfileProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
    </providers>
    </profile>
