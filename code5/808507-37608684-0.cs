    public object GetLastNotEmptyRowOfColumn(string id, string sheet, string column,int startRow,int endRow)
        {
           
            try
            {
               var validColumn =  Regex.IsMatch(column, @"^[a-zA-Z]+$");
                if(!validColumn)
                {
                    throw new Exception($"column can only a letter. value entered : {column}");
                }
                xlBook = xlApp.ActiveWorkbook;
                xlSheet = xlBook.Sheets[sheet];
                xlRange = xlSheet.Range[$"{column}{startRow}", $"{column}{endRow}"];
                object[,] returnVal = xlRange.Value;
                var rows = returnVal.GetLength(0);
               // var cols = returnVal.GetLength(1);
                int count = 1;
                for (int r = 1; r <= rows; r++)
                {
                    var row = returnVal[r, 1];
                    if (row == null) break;
                    count++;                  
                }
               //returns an object : {Count:10,Cell:A9}
                return= new { Count=count-1, Cell=$"{column}{startRow+count-1}" };
            }
            catch (Exception ex)
            {
              ......
            }
            return null;
        }
