    public class MyHtmlHelper<T>
    {
        public string RenderSpan(string name, object value)
        {
            return String.Format("<span name=\"{0}\">{1}</span>", name, value.ToString());
        }
        public string RenderSpan(System.Linq.Expressions.PropertyExpression pe)
        {
            // extract property name and value and render SPAN here
        }
        public string RenderSpan(Expression<Func<object, object>> expr)
        {
            // if specified expr was like x => x.Id then it will actually be parsed as PropertyExpression as in above
        }
    }
