    private DataGridTemplateColumn CreateColumn(int index, string header)
            {
                string cellTemp = string.Format(@"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" 
                xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                 <CheckBox />
                 </DataTemplate>", index);
                DataGridTemplateColumn column = new DataGridTemplateColumn();
                column.Header = header;
                column.HeaderStyle = Resources["Template"] as Style;
                column.CellTemplate = (DataTemplate)XamlReader.Load(cellTemp);
    
           
                return column;
            }
