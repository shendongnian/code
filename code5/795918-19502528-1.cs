     public static void Main()
     {
        string expression = "((159,00)*(1,0))";
        decimal result = evaluate(expression.Replace(".","").Replace(",","."));
     }
     static decimal evaluate(string expression)
     {
        var loDataTable = new DataTable();
        var loDataColumn = new DataColumn("Eval", typeof(double), expression);
        loDataTable.Columns.Add(loDataColumn);
        loDataTable.Rows.Add(0);
        return decimal.Parse(loDataTable.Rows[0]["Eval"].ToString());
     }
