    public class MapInfo {
        private readonly TableCollection _tables = new TableCollection();
        public TableCollection Tables {
            get { return _tables; }
        }
    }
    public class TableCollection : List<Table> {
        public Table this[string name] {
            get { return this.FirstOrDefault(t => t.Name == name); /*using System.Linq;*/ }
        }
    }
    public class Table {
        public string Name { get; set; }
    }
