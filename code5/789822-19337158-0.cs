    //Suppose you create your DataTable like this:
    var dt = new DataTable();
    dt.Columns.Add("Col1",typeof(int));
    dt.Columns.Add("Col2",typeof(int));
    dt.Columns.Add("Col3",typeof(int));
    dt.Columns.Add("Col4",typeof(int));
    //Add some rows to test
    dt.Rows.Add(1, 2, 3, 4);
    dt.Rows.Add(2, 2, 2, 2);
    dt.Rows.Add(4, 2, 3, 3);
    //Use this method to extract the result, remember that it's just demo
    private List<int> GetResultColumn(DataTable dt){
      dt.Columns.Add("Result",typeof(int));
      dt.Columns["Result"].Expression = "(Col1+Col2)-(Col3*Col4)";
      List<int> result = dt.AsEnumerable().Select(row => row.Field<int>("Result")).ToList();
      dt.Columns.Remove("Result");
      return result;
    }
    //Use it
    var result = GetResultColumn(dt);
    //output  {0, -9, 0, -3}
