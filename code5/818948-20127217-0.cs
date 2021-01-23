    private const string SCRIPTBLOCK_BUILDER = "ScriptBlockBuilder";
     
    public static MvcHtmlString ScriptBlock(this WebViewPage webPage,
    Func<dynamic, HelperResult> template)
    {
    if (!webPage.IsAjax)
    {
    var scriptBuilder = webPage.Context.Items[SCRIPTBLOCK_BUILDER]
    as StringBuilder ?? new StringBuilder();
     
    scriptBuilder.Append(template(null).ToHtmlString());
     
    webPage.Context.Items[SCRIPTBLOCK_BUILDER] = scriptBuilder;
     
    return new MvcHtmlString(string.Empty);
    }
    return new MvcHtmlString(template(null).ToHtmlString());
    }
     
    public static MvcHtmlString WriteScriptBlocks(this WebViewPage webPage)
    {
    var scriptBuilder = webPage.Context.Items[SCRIPTBLOCK_BUILDER]
    as StringBuilder ?? new StringBuilder();
     
    return new MvcHtmlString(scriptBuilder.ToString());
    }
