    using System;
    using System.Linq.Expressions;
    using System.Text.Encodings.Web;
    using System.Text.RegularExpressions;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
    namespace Microsoft.AspNetCore.Mvc.Rendering
    {
        public static class HtmlHelpers
        {
            public static IHtmlContent TelephoneLinkFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
            {
                var data = ExpressionMetadataProvider.FromLambdaExpression(expression, helper.ViewData, helper.MetadataProvider);
                var tb = new TagBuilder("a");
                var regEx = new Regex("[^0-9]");
                var phoneNumber = regEx.Replace(data.Model.ToString(), "");
                tb.Attributes.Add("href", $"tel:+{phoneNumber}");
                tb.InnerHtml.Append("" + data.Model);
                var stringWriter = new System.IO.StringWriter();
                tb.WriteTo(stringWriter, HtmlEncoder.Default);
                var tagAsString = stringWriter.ToString();
                return new HtmlContentBuilder().SetHtmlContent(tagAsString);
            }
        }
    }
