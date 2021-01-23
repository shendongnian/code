    public static GetActionNameWithDefault(CMSObject cmsObject)
    {
        return string.IsNullOrEmpty(cmsObject.ActionName)
            ? "Index"
            : cmsObject.ActionName;
    }
    public static GetControllerNameWithDefault(CMSObject cmsObject)
    {
        return string.IsNullOrEmpty(cmsObject.ControllerName)
            ? "Default"
            : cmsObject.ControllerName
    }
    public static MvcHtmlString RenderCMSObject(this HtmlHelper helper, CMSObject cmsObject)
    {
        return helper.Action(
            helper, 
            GetActionNameWithDefault(cmsObject), 
            GetControllerNameWithDefault(cmsObject));
    }
