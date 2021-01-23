    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using Kendo.Mvc.UI.Fluent;
    
    namespace Kendo.Mvc.UI
    {
        public static class KendoExtensions
        {
            public static MvcHtmlString TextBoxFor<TModel>(this WidgetFactory<TModel> helper, Expression<Func<TModel, string>> expression) where TModel : class
            {
                var lKWidget = new TagBuilder("span");
                lKWidget.AddCssClass("k-widget k-numerictextbox");
    
                var lKExpanding = new TagBuilder("span");
                lKExpanding.AddCssClass("k-numeric-wrap k-expand-padding k-state-disabled");
    
                var lTextBoxFor = helper.HtmlHelper.TextBoxFor(expression, new { @class = "k-formatted-value k-input" }).ToHtmlString();
                lKExpanding.InnerHtml += lTextBoxFor;
    
                lKWidget.InnerHtml += lKExpanding;
    
                lKWidget.InnerHtml += helper.HtmlHelper.ValidationMessageFor(expression);
    
                return MvcHtmlString.Create(lKWidget.ToString(TagRenderMode.Normal));
            }
        }
    }
