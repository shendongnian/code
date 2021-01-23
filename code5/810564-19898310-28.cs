    public class MyHtmlHelper<T>
    {
        public string RenderSpan(string name, object value)
        {
            return String.Format("<span id=\"{0}\">{1}</span>", name, value.ToString());
        }
    }
