    for(int i=0;i<dataTableCopy.Rows.Count-1;i++)
       {        
            if (dataTableCopy.Rows[i]["CtryCode"].ToString().Trim().ToUpper().Contains("MM"))
        {
             dataTableCopy.Rows[i].Delete();
        }
      }
 
