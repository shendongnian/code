    namespace Sample.Extensions
    {
        using System;
        using System.Linq.Expressions;
        using System.Web.Mvc;
        using System.Web.Mvc.Html;
    
        public static class TestExtensions
        {
            public static MvcHtmlString FieldFor<TModel>(
                                             this HtmlHelper<TModel> helper,
                                             Expression<Func<TModel, string>> expression)
            {
                var mainDiv = new TagBuilder("div");
                mainDiv.AddCssClass("form-group");
    
                mainDiv.InnerHtml += helper.LabelFor(expression);
    
                var colDiv = new TagBuilder("div");
                colDiv.AddCssClass("col-md-10");
                colDiv.InnerHtml += helper.EditorFor(expression, 
                                                     new
                                                     {
                                                        htmlAttributes =
                                                            new {@class = "form-control"}
                                                     })
                colDiv.InnerHtml += helper.ValidationMessageFor(
                                            expression, 
                                            "", 
                                            new {@class = "text-danger"});
    
                mainDiv.InnerHtml += colDiv;
    
                return new MvcHtmlString(mainDiv.ToString(TagRenderMode.Normal));
            }
        }
    }
