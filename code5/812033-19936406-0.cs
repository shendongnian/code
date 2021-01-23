    public abstract class MyTable {
        public abstract IEnumerable<object> UntypedRows { get; }
    }
    public class MyTable<T> : MyTable {
        public override IEnumerable<object> UntypedRows { get { return _rows; } }
    }
