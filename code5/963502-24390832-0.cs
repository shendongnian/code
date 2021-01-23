    class Program    {  
         public static void WriteToFile(DataTable dataSource, string fileOutputPath, bool firstRowIsColumnHeader, string seperator)   
         {            
            var sw = new StreamWriter(fileOutputPath, false);
            int icolcount = dataSource.Columns.Count;
            if (!firstRowIsColumnHeader)
                    {                
            for (int i = 0; i < icolcount; i++)
            {                    
                sw.Write(dataSource.Columns[i]);                  
                if (i < icolcount - 1)
                                sw.Write(seperator); 
            }                
            sw.Write(sw.NewLine); 
          }
          public static void WriteToFile(DataTable dataSource, string fileOutputPath)
          {
             WriteToFile(dataSource, fileOutputPath, false, ";");
          }
          public static void WriteToFile(DataTable dataSource, string fileOutputPath, bool firstRowIsColumnHeader)
          {
             WriteToFile(dataSource, fileOutputPath, firstRowIsColumnHeader, ";");
          }
    }
