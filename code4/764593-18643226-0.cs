    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    
    namespace MvcApplication.Extensions
    {
        public static class HtmlHelperExtensions
        {
            public static IHtmlString MyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, object dataAttribute)
            {
                MvcHtmlString textBoxFor = InputExtensions.TextBoxFor<TModel, TProperty>(htmlHelper, expression, htmlAttributes);
    
                string stringDataAttributes = string.Empty;
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(dataAttribute))
                {
                    stringDataAttributes+= string.Format("data-{0}=\"{1}\" ", property.Name, property.GetValue(dataAttribute));
                }
    
                string textBoxForText = textBoxFor.ToHtmlString();
                string textBoxWithData = textBoxForText.Insert(textBoxForText.IndexOf("/>"), stringDataAttributes);
    
                return htmlHelper.Raw(textBoxWithData);
            }
        }
    }
