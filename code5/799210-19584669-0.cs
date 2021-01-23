    using System;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    
    namespace TestPlugin
    {
        public class UpdateBoolFields : IPlugin
        {
            public void Execute(IServiceProvider serviceProvider)
            {
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
    
                try
                {
                    if (context.InputParameters.Contains("EntityMoniker") &&
                       context.InputParameters["EntityMoniker"] is EntityReference)
                    {
                        EntityReference targetEntity = (EntityReference)context.InputParameters["EntityMoniker"];
                        IOrganizationService service = factory.CreateOrganizationService(context.UserId);
                        Entity contact = service.Retrieve(targetEntity.LogicalName, targetEntity.Id, new ColumnSet(true));
                        contact["field1"] = false;
                        contact["field2"] = false;
                        contact["field3"] = false;
                        service.Update(contact);
                    }
    
                }
                catch (Exception e)
                {
                    throw new InvalidPluginExecutionException(e.Message);
                }
            }
        }
    }
