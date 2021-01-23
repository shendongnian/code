        Stopwatch sw = new Stopwatch();
        sw.Start();
        Application xlApp = new Application();
        Workbook xlBook = xlApp.Workbooks.Open(@"E:\Temp\StackOverflow\COM_Interop_CS\bin\Debug\demo.xlsx");
        Worksheet wrkSheet = xlBook.Worksheets[1];            
        try
        {
            /// credits go to: 
            /// http://blogs.msdn.com/b/eric_carter/archive/2004/05/04/126190.aspx
            /// 
            /// [cite] when you want to set a range of values to an array, you must declare that array as a 2 
            /// dimensional array where the left-most dimension is the number of rows you are going to set and 
            /// the right-most dimension is the number of columns you are going to set.  
            /// 
            /// Even if you are just setting one column, you can’t create a 1 dimensional array and have it work[/cite]
            Excel.Range range = wrkSheet.Range["A1", "Z100000"];
            int maxRows = 100000, maxCols = 26;
            object[,] values = new object[maxRows, maxCols];
            int counter = 0;
            for (int row = 0; row < maxRows; row++)
            {
                for (int col = 0; col < maxCols; col++)
                {
                    values[row, col] = counter++;
                }
            }
            range.Value2 = values;                
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        xlApp.Visible = true;
        sw.Stop();
        Console.WriteLine("Elapsed: {0}", sw.Elapsed);
