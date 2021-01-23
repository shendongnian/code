     Excel.Application excel = new Excel.Application();
            excel.DisplayAlerts = false;
            excel.Workbooks.Add();
            Excel.Worksheet worksheet = excel.ActiveSheet;
            int rowIndex = 2 ;
            worksheet.Cells[1, "A"] = "List Title";
            worksheet.Cells[1, "B"] = "Item Count";
            Console.WriteLine("Copying the contents to Excel");
            foreach (var list in listCollection)
            {
                worksheet.Cells[rowIndex, "A"] = list.Title;
                worksheet.Cells[rowIndex, "B"] = list.ItemCount;
                rowIndex++;
                //Console.Write("List Title: {0}", list.Title);
                //Console.WriteLine("\t"+"Item Count:"+list.ItemCount);
                
            }
            string fileName = string.Format(@"C:\FileName.xlsx");
            
            worksheet.SaveAs(fileName);
            Console.WriteLine("Export Completed");
           Console.ReadLine();
           excel.Quit();
           GC.Collect();
