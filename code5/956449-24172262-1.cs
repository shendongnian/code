    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using Kendo.Mvc.UI.Fluent;
    
    namespace Kendo.Mvc.UI
    {
        public static class KendoExtensions
        {
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
            public static MvcHtmlString TextBoxFor<TModel, TProperty>(this WidgetFactory<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            {
                return htmlHelper.TextBoxFor(expression, format: null);
            }
    
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
            public static MvcHtmlString TextBoxFor<TModel, TProperty>(this WidgetFactory<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format)
            {
                return htmlHelper.TextBoxFor(expression, format, null);
            }
    
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
            public static MvcHtmlString TextBoxFor<TModel, TProperty>(this WidgetFactory<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
            {
                return htmlHelper.TextBoxFor(expression, null, htmlAttributes);
            }
    
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
            public static MvcHtmlString TextBoxFor<TModel, TProperty>(this WidgetFactory<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
            {
                return htmlHelper.TextBoxFor(expression, format, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }
    
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
            public static MvcHtmlString TextBoxFor<TModel, TProperty>(this WidgetFactory<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
            {
                return htmlHelper.TextBoxFor(expression, null, htmlAttributes);
            }
    
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
            public static MvcHtmlString TextBoxFor<TModel, TProperty>(this WidgetFactory<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes)
            {
                var lKWidget = new TagBuilder("span");
                lKWidget.AddCssClass("k-widget k-numerictextbox");
    
                var lKExpanding = new TagBuilder("span");
                lKExpanding.AddCssClass("k-numeric-wrap k-expand-padding k-state-disabled");
    
                if (htmlAttributes == null) htmlAttributes = new Dictionary<string, object>();
                if (htmlAttributes.ContainsKey("class"))
                {
                    htmlAttributes["class"] += "k-formatted-value k-input";
                } else
                {
                    htmlAttributes.Add("class", "k-formatted-value k-input");
                }
    
                var lTextBoxFor = htmlHelper.HtmlHelper.TextBoxFor(expression, format, htmlAttributes).ToHtmlString();
                lKExpanding.InnerHtml += lTextBoxFor;
    
                lKWidget.InnerHtml += lKExpanding;
    
                lKWidget.InnerHtml += htmlHelper.HtmlHelper.ValidationMessageFor(expression);
    
                return MvcHtmlString.Create(lKWidget.ToString(TagRenderMode.Normal));
            }
        }
    }
