    public class ColumnNameAttribute : Attribute
    {
        public HorizontalAlignment Alignment { get; set;}
        public ColumnNameAttribute(HorizontalAlignment alignment){
            Alignment = alignment;
    }
    
    public class Example(){
        [ColumnName(HorizontalAlignment.Center)]
        public string Column {get; set;}
    }
     private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
       var desc = e.PropertyDescriptor as PropertyDescriptor;
       var att = desc.Attributes[typeof(ColumnNameAttribute)] as ColumnNameAttribute;
       if(att != null){
               e.Column.HeaderStyle = new Style(typeof(DataGridColumnHeader));
               e.Column.HeaderStyle.Setters.Add(new Setter(HorizontalContentAlignmentProperty, att.Alignment));
        }
    
    }
