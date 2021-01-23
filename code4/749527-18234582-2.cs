    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.Collections.ObjectModel;
    using System.Activities;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Workflow;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Sdk.Messages;
    using System.Diagnostics;
    namespace TestWflow
    {
        public class SampleCustomActivity : CodeActivity
        {
            protected override void Execute(CodeActivityContext executionContext)
            {
                //Activity code
                // Get the context service.
                IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>   ();
                IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
                // Use the context service to create an instance of IOrganizationService.
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.InitiatingUserId);
                if (context.Depth == 1)
                {
                    Guid contID = context.PrimaryEntityId;
                    ColumnSet contCols = new ColumnSet("jobtitle");
                    var entity = service.Retrieve("contact", contID, contCols);
                    entity.Attributes["jobtitle"] = "test jobtitle here";
                    service.Update(entity);
                }
            }
        }
    }
