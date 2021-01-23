    var items = db.bar.AsEnumerable().Select(c=>Tuple.Create(i.Prop1, i.Prop2, i.Prop3));
    
    ProcessData(items,
        new DataSelector<Tuple<T1,T2,T3>>("head1", d => d.Prop1.ToString()),
        new DataSelector<Tuple<T1,T2,T3>>("head2", d => d.Prop2.ToString()));
    private class DataSelector<T>
        {
            public DataSelector(string header, Func<T, string> selector)
            {
                Header = header;
                Selector = selector;
            }
            public string Header { get; set; }
            public Func<T, string> Selector { get; set; }
        }
    private static void Process<T>(IEnumerable<T> stuff,
                                   params ColumnDef<T>[] defs) 
    {
        foreach (var item in stuff) {
             // Use all defs like...
             Console.WriteLine(defs[0].Header + ": " + defs[0].Selector(item));
        }
    }
