    [Test]
    public void CustomObservableCollectionT()
    {
        VelocityEngine velocityEngine = new VelocityEngine();
        velocityEngine.Init();
        Table table = new Table();
        table.Columns.Add(new TableColumn { Name = "Full Name" });
        table.Columns.Add(new TableColumn { Name = "Email Address" });
        table.Columns.Add(new TableColumn { Name = "DOB" });
        VelocityContext context = new VelocityContext();
        context.Put("table", table);
        using (StringWriter sw = new StringWriter())
        {
            velocityEngine.Evaluate(context, sw, "",
                "#foreach ($c in $table.Columns)\r\n" +
                "$c.Name\r\n" +
                "#end"
            );
            Assert.AreEqual(
                "Full Name\r\n" +
                "Email Address\r\n" +
                "DOB\r\n",
                sw.ToString());
        }
    }
    public class MegaList<T> : ObservableCollection<T>
    {
    }
    public class Table
    {
        private readonly MegaList<TableColumn> _columns = new MegaList<TableColumn>();
        public MegaList<TableColumn> Columns
        {
            get { return _columns; }
        }
        public List<TableColumn> ColumnList
        {
            get { return _columns.ToList(); }
        }
        public ObservableCollection<TableColumn> ColumnCollection
        {
            get { return new ObservableCollection<TableColumn>(_columns); }
        }
    }
    public class TableColumn
    {
        public string Name { get; set; }
    }
