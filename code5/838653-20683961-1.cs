    public void myDataGrid_Loaded(object sender, EventArgs e)
    {
            var dataTemplate = new DataTemplate();
            FrameworkElementFactory tbHolder1 = new FrameworkElementFactory(typeof(Label));
            tbHolder1.SetBinding(Label.ContentProperty, new Binding("Id"));
            dataTemplate.VisualTree = tbHolder1;
            dataTemplate.DataType = typeof(DataGridTemplateColumn);
            templatecolumnId.CellTemplate = dataTemplate;
            dataTemplate = new DataTemplate();
            FrameworkElementFactory tbHolder2 = new FrameworkElementFactory(typeof(TextBlock));
            tbHolder2.SetBinding(TextBlock.TextProperty, new Binding("Name"));
            dataTemplate.VisualTree = tbHolder2;
            dataTemplate.DataType = typeof(DataGridTemplateColumn);
            templatecolumnName.CellTemplate = dataTemplate;
            dataTemplate = new DataTemplate();
            FrameworkElementFactory tbHolder3 = new FrameworkElementFactory(typeof(DataGrid));
            tbHolder3.SetBinding(DataGrid.ItemsSourceProperty, new Binding("Address"));
            tbHolder3.SetValue(DataGrid.AutoGenerateColumnsProperty, true);
            dataTemplate.VisualTree = tbHolder3;
            dataTemplate.DataType = typeof(DataGridTemplateColumn);
            templateColumnInnerTable.CellTemplate = dataTemplate;
        }
