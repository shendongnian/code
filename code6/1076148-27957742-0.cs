            IPluginExecutionContext context = localContext.PluginExecutionContext;
            IOrganizationService service = localContext.OrganizationService;
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parmameters.
                Entity entity = (Entity)context.InputParameters["Target"];
                try
                {
                    if (entity.LogicalName == "list" && entity.Attributes.Contains("gbs_lastusedonoriginal") && entity["gbs_lastusedonoriginal"] != null)
                    {
                        if (entity.Attributes.Contains("lastusedon") )
                            entity.Attributes["lastusedon"] = entity.Attributes["gbs_lastusedonoriginal"];
                        else entity.Attributes.Add("lastusedon", entity.Attributes["gbs_lastusedonoriginal"];                        
                    }
                }
                catch (FaultException ex)
                {
                    throw new InvalidPluginExecutionException("An error occured in the plug-in.", ex);
                }
            }
                
