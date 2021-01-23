    public class MyDataGridTemplateColumn : DataGridTemplateColumn
    {
        public string ColumnName
        {
            get;
            set;
        }
        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            ContentPresenter cp = (ContentPresenter)base.GenerateElement(cell, dataItem);
            BindingOperations.SetBinding(cp, ContentPresenter.ContentProperty, new Binding(this.ColumnName));
            return cp;
        }
    }
    public class MyData
    {
        public MyData(string name, bool data) { nameData = name; showData = data; }
        public string nameData { get; set; }
        public bool showData { get; set; }
    }
