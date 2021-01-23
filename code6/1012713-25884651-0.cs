    using System.Linq;
    ...
    var columnNames = new List<string> { "one", "two", "three" };
    var columnsToDelete = ResultsLogTab_ListView.Columns.Where(c => !columnNames.Contains(c.Name));
    foreach(var column in columnsToDelete)
    {
         ResultsLogTab_ListView.Columns.Remove(column);
    }
