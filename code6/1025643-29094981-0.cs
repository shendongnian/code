        public void ImportXLX()
            {
    
    string filePath = string.Format("{0}/{1}", Server.MapPath("~/Content/UploadedFolder"), @"C:\Users\Vipin\Desktop\Sheets\MyXL6.xlsx");
                        if (System.IO.File.Exists(filePath))
                            System.IO.File.Delete(filePath);
                        Request.Files["xlsFile"].SaveAs(filePath);
                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
    }
