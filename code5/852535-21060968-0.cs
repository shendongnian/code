    var baseTemplates = GetAllTemplate.Children;
    var baseTemplateIds = baseTemplates.Select(item => item.ID.ToString());
    var fieldValue = String.Join("|",baseTemplateIds);
    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
        try
        {
            MasterItem.Editing.BeginEdit();
            MasterItem["__Base template"] = fieldValue;
        }
        finally
        {   
            MasterItem.Editing.EndEdit();
        }
    }
