    public static string ContentType { get; set; }
    public static string FilePath { get; set; }
    public static string FileName { get; set; }
    public static byte[] Bites { get; set; }
    public void ExportToExcel(int BatchID,string BatchName)//is called first to set the variables
        {
            string contentType;
            byte[] bites;
            string ret = DataAccess.ExportUtility.CreateExcelFile(BatchID, BatchName,out contentType, out bites);
            ContentType = contentType;
            Bites = bites;
            
            FileName = ret[1];
                
            
           
        }
        public ActionResult DownloadExcelFile()//is then called to download the file
        {
            return File(Bites, ContentType, FileName);
            
        }
