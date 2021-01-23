    List<string> rangeToList(Microsoft.Office.Interop.Excel.Range inputRng)
    {
    	object[,] cellValues = (object[,])inputRng.Value2;
    	List<string> lst = cellValues.Cast<object>().ToList().ConvertAll(x=> Convert.ToString(x));
    	return lst;
    }
