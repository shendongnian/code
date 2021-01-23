        public DataTemplate BuildDataTemplate(Conflict conflict)
        {
            DataTemplate template = new DataTemplate();
            // Set a stackpanel to hold all the resolution buttons
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(StackPanel));
            template.VisualTree = factory;
            // Iterate through the resolution
            foreach (var resolution in conflict.Resolutions)
            {
                // Create a button
                FrameworkElementFactory childFactory = new FrameworkElementFactory(typeof(Button));
                
                // Bind it's content to the Name property of the resolution
                childFactory.SetBinding(Button.ContentProperty, new Binding("Name"));
                // Bind it's resolve method with the button's click event
                childFactory.AddHandler(Button.ClickEvent, new Action(() => resolution.Resolve());
                // Append button to stackpanel
                factory.AppendChild(childFactory);
            }
            return template;
        }
