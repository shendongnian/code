    public static string[] CreateExcelFile(int batchid,string batchName,out string ContentType, out byte[] Bites)
        {
            
            string fileName = batchName + " Reason_Code_Export.xlsx";
            
            var serverPath = HttpContext.Current.Server.MapPath("~/ExportFiles/");
            DirectoryInfo outputDir = new DirectoryInfo(serverPath);
            byte[] bites;
            FileInfo newfile = new FileInfo(outputDir.FullName + fileName);
            if (newfile.Exists)
            {
                newfile.Delete();
                newfile = new FileInfo(outputDir.FullName + fileName);
            }
            Dictionary<string,int> MAData = PolicyDataAccess.GetMatchActionData(batchid);
            MemoryStream MS = new MemoryStream();
            ExcelPackage package;
            using (package = new ExcelPackage(newfile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(batchName);
                worksheet.Cells["A1"].Value = batchName + " Reason_Code_Export";
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:B1"].Merge = true;
                worksheet.Cells["A1:B1"].Style.Font.Bold = true;
                worksheet.Cells["A2"].Value = "Reason Code";
                worksheet.Cells["B2"].Value = "Number of Reason Codes Selected";
                worksheet.Cells["A2:B2"].Style.Font.Bold = true;
                int row = 3;
                int col = 1;
                foreach (KeyValuePair<string,int> MA in MAData)
                {
                    worksheet.Cells[row, col].Value = MA.Key;
                    worksheet.Cells[row, col + 1].Value = MA.Value;
                    row++;
                }
                worksheet.Column(1).Width = 34.29;
                worksheet.Column(2).Width = 34.29;
                package.Workbook.Properties.Title = batchName + " Reason_Code_Export";
                package.Workbook.Properties.Author = "Intranet Application: Unclaimed Properties";
                package.Workbook.Properties.Company = "Assurity Life 2013";
                Bites = package.GetAsByteArray();
                //package.SaveAs(newfile);//MS);
                
            }
            MS.Position = 0;
            var rl = serverPath + fileName;
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            ContentType = contentType;
            FileStreamResult FSR = new FileStreamResult(MS, contentType);
            FSR.FileDownloadName = fileName;
            string[] ret = new string[2];
            ret[0] = serverPath;
            ret[1] = fileName;
            return ret;
        }
