        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            System.Windows.Controls.DataGridTemplateColumn templateColumn = new System.Windows.Controls.DataGridTemplateColumn();
            templateColumn.Header = e.PropertyName;
            DataTemplate template = new DataTemplate();
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(StackPanel));
            template.VisualTree = factory;
            FrameworkElementFactory childFactory = new FrameworkElementFactory(typeof(TextBox));
            childFactory.SetBinding(TextBox.TextProperty, new Binding(e.PropertyName));
            factory.AppendChild(childFactory);
            templateColumn.CellEditingTemplate = template;
            template = new DataTemplate();
            factory = new FrameworkElementFactory(typeof(StackPanel));
            template.VisualTree = factory;
            childFactory = new FrameworkElementFactory(typeof(TextBlock));
            childFactory.SetBinding(TextBlock.TextProperty, new Binding(e.PropertyName));
            factory.AppendChild(childFactory);
            templateColumn.CellTemplate = template;
            e.Column = templateColumn;
        }
