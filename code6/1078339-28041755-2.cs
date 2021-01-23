    using Microsoft.Xrm.Sdk.Client;
...
    var service = OrganizationServiceFactory.CreateOrganizationService(PluginExecutionContext.UserId);
    using (var context = new OrganizationServiceContext(service))
    {
         List<Entity> myCompanyRecords = context.CreateQuery("cs_company").Where(o => ((EntityReference)o["cs_accountid").Id.Equals(id)).ToList();
    }
