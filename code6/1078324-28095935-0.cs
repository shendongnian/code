        public string [] dates = {"COLUMN NAMES", "THAT NEED", "TO BE DATES"};
        public void addColumnTemplates(object sender, DataGridAutoGeneratingColumnEventArgs e){
            string header = e.Column.Header.ToString();
            if ( dates.Contains(header) )
            {
                MyDataGridTemplateColumn col = new MyDataGridTemplateColumn();
                col.ColumnName = e.PropertyName; 
                col.CellTemplate = (DataTemplate)FindResource("datePickerTemplate");
                e.Column = col;
                e.Column.Header = e.PropertyName;
            }
             
        }
