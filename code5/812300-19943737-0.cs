    public String GetExcelType(dynamic thing)
    {   
    	Type type = GetExcelTypeForComObject(thing)
        if(type == typeof(Microsoft.Office.Interop.Excel.Chart))
        {
            return "[CHART]";
        }
        else if (type == typeof(Microsoft.Office.Interop.Excel.Range))
        {
            return "[TABLE]";
        }
    
        return "[UNKNOWN]";
    }
