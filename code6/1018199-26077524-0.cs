    public class CustomField
    {
        public CustomField(MvcHtmlString label, MvcHtmlString input)
        {
            this.Label = label;
            this.Input = input;
        }
        public MvcHtmlString Label { get; private set; }
        public MvcHtmlString Input { get; private set; }
        public override string ToString()
        {
            return string.Format("{0}{1}", this.Label, this.Input);
        }
    }
    public class CustomPanel<TModel>
    {
        public CustomPanel(HtmlHelper<TModel> html)
        {
            if (html == null) throw new ArgumentNullException("html");
            this.Html = html;
            this.Fields = new List<CustomField>();
        }
        private HtmlHelper<TModel> Html { get; set; }
        private List<CustomField> Fields { get; set; }
        public void AddField<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            this.Fields.Add(new CustomField(this.Html.LabelFor<TModel, TValue>(expression), this.Html.TextBoxFor<TModel, TValue>(expression)));
        }
        public MvcHtmlString GetHtml()
        {
            var sb = new StringBuilder();
            foreach (var field in this.Fields)
                sb.AppendFormat("{0} <br>", field);
            return new MvcHtmlString(sb.ToString());
        }
    }
    public static class PanelExtension
    {
        public static CustomPanel<TModel> CreatePanel<TModel>(this HtmlHelper<TModel> html)
        {
            return new CustomPanel<TModel>(html);
        }
    }
