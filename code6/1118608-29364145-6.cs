    class WidgetUser
    {
        public WidgetUser(IWidgetFactory widgetFactory)
        {
            this.widgetFactory = widgetFactory;
        }
        public void MakeAndUse(string serializedWidget)
        {
            var widget = widgetFactory.Create(serializedWidget);
            Use(widget);
        }
        private readonly IWidgetFactory widgetFactory;
    }
