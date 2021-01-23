    namespace GenericsIssueExample
    {
        interface IGroup<TRow, TEntry>
            where TRow : IRow<TEntry>
            where TEntry : IEntry 
        {
            TRow[] Rows
            {
                get;
                set;
            }
        }
        interface IRow<TEntry> where TEntry : IEntry
        {
            TEntry[] Entries
            {
                get;
                set;
            }
        }
        interface IEntry
        {
            int Value
            {
                get;
                set;
            }
        }
        class ExampleGroup : IGroup<ExampleRow, ExampleEntry>
        {
            private ExampleRow[] rows;
            public ExampleRow[] Rows
            {
                get { return rows; }
                set { rows = value; }
            }
        }
        class ExampleRow : IRow<ExampleEntry>
        {
            private ExampleEntry[] entries;
            public ExampleEntry[] Entries
            {
                get { return entries; }
                set { entries = value; }
            }
        }
        class ExampleEntry : IEntry
        {
            private int val = 0;
            public int Value
            {
                get { return val; }
                set { val = value; }
            }
        }
    }
