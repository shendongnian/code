    using System.Web.Mvc.Html;
           
    namespace MyHelper
    {
            public static class CustomLink
            {
                public static IHtmlString CreateSubjectTree(this HtmlHelper html, SqlConnection con)
                {
                    // magic logic
                    var link = html.ActionLink("Blabla", "Read", "Chapter").ToHtmlString();          
                    return new MvcHtmlString(link);
                }
        
            }
    }
    
        Use in View:
         @Html.CreateSubjectTree(SqlConnection:con)
