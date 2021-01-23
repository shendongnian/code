            try
            {
                string mySheet = @"E:\7.xlsx";
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                Workbook wb = excelApp.Workbooks.Open(mySheet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
