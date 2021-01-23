    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web;
    using global::System.Web.Mvc;
    public static class TextAreaHelperExtension
    {
        public static MvcHtmlString TextAreaHelperFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return TextAreaHelperFor(htmlHelper, expression, null);
        }
        public static MvcHtmlString TextAreaHelperFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return TextAreaHelperFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        public static MvcHtmlString TextAreaHelperFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            return TextAreaHelper(htmlHelper,
                                    ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
                                    ExpressionHelper.GetExpressionText(expression),
                                    htmlAttributes);
        }
        internal static MvcHtmlString TextAreaHelper(HtmlHelper htmlHelper, ModelMetadata modelMetadata, string name, IDictionary<string, object> htmlAttributes, string innerHtmlPrefix = null)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException();
            }
            TagBuilder tagBuilder = new TagBuilder("textarea");
            tagBuilder.GenerateId(fullName);
            tagBuilder.MergeAttributes(htmlAttributes, true);
            tagBuilder.MergeAttribute("name", fullName, true);
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState) && modelState.Errors.Count > 0)
            {
                tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }
            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, modelMetadata));
            string value;
            if (modelState != null && modelState.Value != null)
            {
                value = modelState.Value.AttemptedValue;
            }
            else if (modelMetadata.Model != null)
            {
                value = modelMetadata.Model.ToString();
            }
            else
            {
                value = String.Empty;
            }
            tagBuilder.InnerHtml = (innerHtmlPrefix ?? Environment.NewLine) + HttpUtility.HtmlEncode(value);
            return tagBuilder.ToMvcHtmlString(TagRenderMode.Normal);
        }
        internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
