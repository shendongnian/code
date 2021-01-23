        FileInfo plik1 = new FileInfo(file1);
        FileInfo plik2 = new FileInfo(file2);
        FileInfo path = new FileInfo("C:\\Users\\bddddz\\Desktop\\asd\\final.xlsx");
        using (ExcelPackage xlPackageNew = new ExcelPackage(path))
        using (ExcelPackage xlPackage = new ExcelPackage(plik1))
        using (ExcelPackage xlPackage2 = new ExcelPackage(plik2))
        {
            var worksheet2 = xlPackage2.Workbook.Worksheets[1];
            var worksheet = xlPackage.Workbook.Worksheets[1];
            var worksheet3 = xlPackageNew.Workbook.Worksheets.Add("new"); 
            int j = 0;
            for (j=1; j<2500000; j++)
            {
                if (worksheet.Cells[j, 1].Value == worksheet2.Cells[j, 2].Value)
                {
                    worksheet3.Cells[j, 13].Value = worksheet2.Cells[j, 14].Value;
                    worksheet3.Cells[j, 14].Value = worksheet2.Cells[j, 16].Value;
                }
            }
            xlPackageNew.Save();
        }
 
