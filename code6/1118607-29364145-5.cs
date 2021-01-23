    sealed class MyWidgetFactory : IWidgetFactory
    {
        public IWidget Create(string serialisedWidget)
        {
            return MyWidget.Deserialize(serialisedWidget);
        }
    }
