    foreach (DataRow row in table.Rows) {
       var rowSum = 0d;
       foreach (DataColumn column in row.Table.Columns) {
	//if row[column] is number
            rowSum += Convert.ToDouble(row[column]));
	//}
	}
	//at his point you have the the colums sum
    }
