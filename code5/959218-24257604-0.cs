    public sealed class ElementsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ReleaseTemplate { get; set; }
        public DataTemplate ChangeTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = item as XElement;
            if (element != null)
            {
                switch (element.Name.ToString())
                {
                    case "Release":
                        return ReleaseTemplate;
                    case "Change":
                        return ChangeTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
