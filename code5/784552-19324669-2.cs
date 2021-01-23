    public static string ContentType { get; set; }
    public static string FilePath { get; set; }
    public static string FileName { get; set; }
    public static byte[] Bytes { get; set; }
    public void ExportToExcel(int BatchID,string BatchName)//is called first to set the variables
        {
            string contentType;
            byte[] bytes;
            string ret = DataAccess.ExportUtility.CreateExcelFile(BatchID, BatchName,out contentType, out bytes);
            ContentType = contentType;
            Bytes = bytes;
            
            FileName = ret[1];
                
            
           
        }
        public ActionResult DownloadExcelFile()//is then called to download the file
        {
            return File(Bytes, ContentType, FileName);
            
        }
