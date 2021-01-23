     foreach (DataRow row in table42.Rows)
       {
    		if (row.Item("ACTION_TYPE").ToString() != rowtype)
    		{
    			writer.Write(rowtype);
    		}	
            string value = string.Format("{0}                  {0}         {1}                 {2}",      row[1], row[2], row[3]); // how you format is up to you (spaces, tabs, delimiter, etc)                                   
            commaDelimitedText.AppendLine(value);
       }
