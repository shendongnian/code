    using System;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    namespace YourAssembly.Html
    {
      public static class FieldHelper
      {
        public static MvcHtmlString FieldFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
          MvcHtmlString label = LabelExtensions.LabelFor(helper, expression, new { @class = "control-label col-md-2" });
          MvcHtmlString editor = EditorExtensions.EditorFor(helper, expression, new { htmlAttributes = new {@class = "form-control"}})
           MvcHtmlString validation = ValidationExtensions.ValidationMessageFor(helper, expression, null, new { @class = "text-danger" });
           StringBuilder html = new StringBuilder();
           html.Append(editor);
           html.Append(validation);
           TagBuilder innerDiv = new TagBuilder("div");
           innerDiv.AddCssClass("col-md-10");
           innerDiv.InnerHtml = html.ToString();
           html = new StringBuilder();
           html.Append(label);
           html.Append(innerDiv.ToString());
           TagBuilder outerDiv = new TagBuilder("div");
           outerDiv.AddCssClass("form-group");
           outerDiv.InnerHtml = html.ToString();
           return MvcHtmlString.Create(outerDiv.ToString());
        }
      }
    }
