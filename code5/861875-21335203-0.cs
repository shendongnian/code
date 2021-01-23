    public class HelperFactory<TModel>
    {
        public HelperFactory(HtmlHelper<TModel> htmlHelper)
        {
            this.HtmlHelper = htmlHelper;
        }
        public HtmlHelper<TModel> HtmlHelper { get; private set; }
        public virtual EditorBuilder<TModel, TProperty> CustomEditorFor<TProperty>(Expression<Func<TModel, TProperty>> expression, EditorOptions options, object htmlAttributes)
        {
            return new EditorBuilder<TModel, TProperty>(this.HtmlHelper,
                       expression,
                       options,
                       htmlAttributes);
        }
    }
