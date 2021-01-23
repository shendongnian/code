        string equationString = "(7+((8%2)(7%3)))";
        string explicitMultiply = equationString.Replace(")(", ")*(");
        double f = Evaluate(explicitMultiply);
        static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
