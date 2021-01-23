    public static class DoubleBoxHelper
    {
        public static MvcHtmlString DoubleBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var builder = new StringBuilder();
            builder.AppendLine(htmlHelper.TextBoxFor(expression, new {bop = 1}).ToHtmlString());
            return null;
        }
        internal class Program
        {
            private static void Main(string[] args)
            {
                HtmlHelper<DoubleNumber> helper = ...
                helper.DoubleBoxFor(g => g.Num1);
            }
        }
    }
