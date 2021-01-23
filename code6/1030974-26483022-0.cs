    namespace MyHelpers.Html
    {
      public static class ReadOnlyHelpers
      {
        public static MvcHtmlString ReadOnlyTextBoxIf<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, bool isReadOnly)
        {
          object attributes = isReadOnly ? new { @readonly = "readonly" } : null;
          return InputExtensions.TextBoxFor(helper, expression, attributes);
        }
      }
    }
