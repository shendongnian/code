    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Helpers;
	using System.Web.Mvc.Html;
	using System.Linq.Expressions;
	namespace MyAppName.Helpers
	{
		public static class HtmlPrivilegedHelper
		{
			public static MvcHtmlString PrivilegedEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
			{
                // You can access the Model passed to the strongly typed view this way
				if (html.ViewData.Model.CurrentUser.Admin)
				{
					return html.EditorFor(expression);
				}
				return html.DisplayFor(expression);
			}
		}
	}
