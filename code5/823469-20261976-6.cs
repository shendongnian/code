        using System;
        using System.Linq;
        using System.Linq.Expressions;
        using System.Web;
        using System.Web.Mvc;
        using System.Web.Mvc.Html;
    
        namespace MvcApplication1.HtmlHelpers
        {
            public static class HtmlHelpers
            {
                public static MvcHtmlString DisplayFieldFor<TModel, TValue>(
                    this HtmlHelper<TModel> helper, 
                    Expression<Func<TModel, TValue>> field)
                {
                    var labelString = helper.LabelFor(field);
                    var displayString = helper.DisplayFor(field);
    
                    return MvcHtmlString.Create(
                        labelString.ToString() + 
                        displayString.ToString());
                }
            }
        }
