    public class Extensions
    {
        public static string EditorWithReadOnlyFor(
            this HtmlHelper helper,
            Expression<Func<TModel,TProperty>> expression,
            bool readonly)
        {
            // Use bool to manipulate attributes then
            return helper.EditorFor(expression, /* add attributes */ )
        }
    }
