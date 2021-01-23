    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="microsoft.xrm.client" type="Microsoft.Xrm.Client.Configuration.CrmSection, Microsoft.Xrm.Client"/>
      </configSections>
      <connectionStrings>
      <!-- On-Premise with integrated Authentication -->
          <add name="MyOnPremiseConnection" connectionString="Url=http://SERVER-NAME/ORG-NAME/XRMServices/2011/Organization.svc;" />
      </connectionStrings>
      <microsoft.xrm.client>
        <contexts default="MyOnPremiseContext">
          <!-- On Premise CRM-->
          <add name="MyOnPremiseContext" connectionStringName="MyOnPremiseConnection" serviceName="MyService" />
        </contexts>
        <services default="MyService">
          <add name="MyService" serviceCacheName="Xrm" />
        </services>
        <serviceCache default="Xrm">
          <add name="Xrm" type="Microsoft.Xrm.Client.Services.OrganizationServiceCache, Microsoft.Xrm.Client" cacheMode="Disabled" />
        </serviceCache>
      </microsoft.xrm.client>
    </configuration>
