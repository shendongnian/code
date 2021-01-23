           var excelApp1 = new Excel.Application();
            // Make the object visible.
            excelApp1.Visible = true;
             
            // Create a new, empty workbook and add it to the collection returned 
            // by property Workbooks. The new workbook becomes the active workbook.
            // Add has an optional parameter for specifying a praticular template. 
            // Because no argument is sent in this example, Add creates a new workbook. 
            excelApp1.Workbooks.Add();
            // This example uses a single workSheet. 
            Excel._Worksheet workSheet1 = excelApp1.ActiveSheet;
