    using System.IO;
    using System.Windows;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    
    // ...
            using (var file = new FileStream(workbookLocation, FileMode.Open, FileAccess.Read))
            {
              var workbook = new XSSFWorkbook(file);
              var nameInfo = workbook.GetName("TheTable");
              var tableRange = nameInfo.RefersToFormula;
              // Do stuff with the table
            }
