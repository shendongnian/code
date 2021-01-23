    static void Main(string[] args)
    {
        // some sample data
        var dt = new DataTable();
        dt.Columns.Add("NAME", typeof(string));
        dt.Columns.Add("CITY", typeof(string));
        dt.Columns.Add("STATE", typeof(string));
        dt.Columns.Add("VALUE", typeof(double));
        dt.Rows.Add("Mike", "Tallahassee", "FL", 3);
        dt.Rows.Add("Mike", "Tallahassee", "FL", 6);
        dt.Rows.Add("Steve", "Tallahassee", "FL", 5);
        dt.Rows.Add("Steve", "Tallahassee", "FL", 10);
        dt.Rows.Add("Steve", "Orlando", "FL", 7);
        dt.Rows.Add("Steve", "Orlando", "FL", 14);
        dt.Rows.Add("Mike", "Orlando", "NY", 11);
        dt.Rows.Add("Mike", "Orlando", "NY", 22);
        // some "configuration" data
        IEnumerable<string> columnsToGroupBy = new[] {"CITY", "STATE"};
        string columnToAggregate = "VALUE";
        // the test routine
        foreach (var group in dt.AsEnumerable().GroupBy(r => new NTuple<object>(from column in columnsToGroupBy select r[column])))
        {
            foreach (var keyValue in group.Key.Values)
            {
                Debug.Write(keyValue);
                Debug.Write(':');
            }
            Debug.WriteLine(group.Sum(r => Convert.ToDouble(r[columnToAggregate])));
        }
    }
