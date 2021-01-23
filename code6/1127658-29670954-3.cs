    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Activities;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Workflow;
    
    namespace TestCustomWorkflowActivity
    {
    
            public class SampleCustomActivity : CodeActivity 
            {
                protected override void Execute(CodeActivityContext executionContext)
                {
                    //Create the tracing service
                    ITracingService tracingService = executionContext.GetExtension<ITracingService>();
    
                    //Create the context
                    IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
                    IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
                    IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
    
                }
            }
    }
