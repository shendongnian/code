    var table = new FnTable();
    table.Add(14, () => Console.Out.WriteLine("14"));
    table.Add(15, () => Console.Out.WriteLine("15"));
    table.Add(16, () => { throw new InvalidOperationException(); });
    int[] results = {13, 14, 15};
    table.ExecuteFirstFrom(results);
