    private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
       if (e.PropertyType == typeof (Int32))
       {
           if (e.Column != null)
           {
              var dgct = new DataGridTemplateColumn();
              var cName = e.Column.Header as string;
              var b = new Binding(cName);
              var sfactory = new FrameworkElementFactory(typeof(TextBlock));
              sfactory.SetValue(TextBlock.TextProperty, b);
              sfactory.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right);
              var cellTemplate = new DataTemplate();
              cellTemplate.VisualTree = sfactory;
              dgct.CellTemplate = cellTemplate;
 
              dgct.Header = cName;
              dgct.SortMemberPath = cName;
 
              e.Column = dgct;
           }
       }
        
       ... *and so on for all your data types*
