    public class MyTable<T> : ITable where T : IRow
    {
        private List<T> _rows;
        private MyTableDefinition _tableDef;
        public MyTable() { ... }
        public MyTableDefinition TableDef { get { return _tableDef; } }
        public void Print() { ForEachRow(row => row.Print()); }
        public void ForEachRow(Action<IRow> action)
        {
            foreach (T row in _rows)
            {
                action(row);
            }
        }
    }
    public class MyRow : IRow
    {
        private int _whateverFieldsYouWant;
        public void Print() { ... }
    }
