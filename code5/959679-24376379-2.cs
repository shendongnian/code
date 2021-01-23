       public void RegisterDataTemplate(Type viewModelType, Type dataTemplateType, string Tag="")
        {
            var template = BuildDataTemplate(viewModelType, dataTemplateType) ;
            templates.Add(viewModelType.ToString() + Tag, template);
        }
        private DataTemplate BuildDataTemplate(Type viewModelType, Type viewType)
        {
            var template = new DataTemplate()
            {
                DataType = viewModelType,
                VisualTree = new FrameworkElementFactory(viewType)
            };
            return template;
        }
