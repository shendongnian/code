    public interface ITable
    {
        MyTableDefinition TableDef { get; }
        void Print();
        void ForEachRow(Action<IRow> action);
    }
    public interface IRow
    {
        void Print();
    }
