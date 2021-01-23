    @using System.Web.Mvc.Html
    @helper BoxTitle(System.Web.Mvc.WebViewPage wvp, string CustomButtons)
    {
        if (!string.IsNullOrEmpty(CustomButtons))
        {
            @wvp.Html.Raw(CustomButtons)
        }
    }
