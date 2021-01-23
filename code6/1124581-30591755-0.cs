    string expression = "330200000*450000"; // or whatever your user has entered
    expression = Regex.Replace(
        expression, 
        @"\d+(\.\d+)?", 
        m => {
             var x = m.ToString(); 
             return x.Contains(".") ? x : string.Format("{0}.0", x);
        }
    );
    var loDataTable = new DataTable();
    var computedValue = loDataTable.Compute(expression, string.Empty);
