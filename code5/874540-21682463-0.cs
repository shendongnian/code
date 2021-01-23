    protected String GetPluginExecutionInfo(IPluginExecutionContext context)
    {
        var lines = new List<String>();
        var target = GetTarget<Entity>(context);
    
        lines.Add("MessageName: " + context.MessageName);
        lines.Add("PrimaryEntityName: " + context.PrimaryEntityName);
        lines.Add("PrimaryEntityId: " + context.PrimaryEntityId);
        lines.Add("BusinessUnitId: " + context.BusinessUnitId);
        lines.Add("CorrelationId: " + context.CorrelationId);
        lines.Add("Depth: " + context.Depth);
        lines.Add("Has Parent Context: " + (context.ParentContext != null));
        lines.Add("InitiatingUserId: " + context.InitiatingUserId);
        AddParameters(lines, context.InputParameters, "Input Parameters");
        lines.Add("IsInTransaction: " + context.IsInTransaction);
        lines.Add("IsolationMode: " + context.IsolationMode);
        lines.Add("Mode: " + context.Mode);
        lines.Add("OperationCreatedOn: " + context.OperationCreatedOn);
        lines.Add("OperationId: " + context.OperationId);
        lines.Add("Organization: " + context.OrganizationName + "(" + context.OrganizationId + ")");
        AddParameters(lines, context.OutputParameters, "Output Parameters");
        AddEntityReference(lines, context.OwningExtension, "OwningExtension");
        AddEntityImages(lines, context.PostEntityImages, "Post Entity Images");
        AddEntityImages(lines, context.PreEntityImages, "Pre Entity Images");
        lines.Add("SecondaryEntityName: " + context.SecondaryEntityName);
        AddParameters(lines, context.SharedVariables, "Shared Variables");
        lines.Add("Stage: " + context.Stage);
        lines.Add("UserId: " + context.UserId);
    
        if (target == null || target.Attributes.Count == 0)
        {
            lines.Add("Target: Empty ");
        }
        else
        {
            lines.Add("* Target " + target.ToEntityReference().GetNameId() + " *");
            lines.Add(target.ToStringAttributes("    Target[{0}]: {1}"));
        }
    
        lines.Add("* App Config Values *");
        foreach (var key in ConfigurationManager.AppSettings.AllKeys)
        {
            lines.Add("    [" + key + "]: " + ConfigurationManager.AppSettings[key]);
        }
    
        return String.Join(Environment.NewLine, lines);
    }
    
    private static void AddEntityReference(List<string> nameValuePairs, EntityReference entity, string name)
    {
        if (entity != null)
        {
            nameValuePairs.Add(name + ": " + entity.GetNameId());
        }
    }
    
    private static void AddEntityImages(List<string> nameValuePairs, EntityImageCollection images, string name)
    {
        if (images != null && images.Count > 0)
        {
            nameValuePairs.Add("** " + name + " **");
            foreach (var image in images)
            {
                if (image.Value == null || image.Value.Attributes.Count == 0)
                {
                    nameValuePairs.Add("    Image[" + image.Key + "] " + image.Value + ": Empty");
                }
                else
                {
                    nameValuePairs.Add("*   Image[" + image.Key + "] " + image.Value.ToEntityReference().GetNameId() + "   *
                    nameValuePairs.Add(image.Value.ToStringAttributes("        Entity[{0}]: {1}"));
                }
            }
        }
        else
        {
            nameValuePairs.Add(name + ": Empty");
        }
    }
    
    private static void AddParameters(List<string> nameValuePairs, ParameterCollection parameters, string name)
    {
        if (parameters != null && parameters.Count > 0)
        {
            nameValuePairs.Add("* " + name + " *");
            foreach (var param in parameters)
            {
                nameValuePairs.Add("    Param[" + param.Key + "]: " + param.Value);
            }
        }
        else
        {
            nameValuePairs.Add(name + ": Empty");
        }
    }
    public static String ToStringAttributes(this Entity entity, string attributeFormat = "[{0}]: {1}")
    {
        return String.Join(Environment.NewLine, entity.Attributes.Select(att => 
            String.Format(attributeFormat, att.Key, GetAttributeValue(att.Value))));
    }
    
    private static string GetAttributeValue(object value)
    {
        if (value == null)
        {
            return "Null";
        }
    
        var osv = value as OptionSetValue;
        if (osv != null)
        {
            return osv.Value.ToString();
        }
    
        var entity = value as EntityReference;
        if (entity != null)
        {
            return entity.GetNameId();
        }
    
        return value.ToString();
    }
