    namespace OptionalAttributeDirectory
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Calling the helper method GenerateReport only with required parameter
                GenerateReport(1);
                //Calling the helper method GenerateReport with required and optional parameters
                GenerateReport(1, @"C:\");
            }
    
            public static void GenerateReport(int ReportId, 
                [System.Runtime.InteropServices.OptionalAttribute] string saveToFolderPath)
    
            {
    
                if (saveToFolderPath == null)
                {
                    saveToFolderPath = System.IO.Directory.GetCurrentDirectory();
                }
                Console.WriteLine("The report - " + ReportId + 
                      " saved in the folder " + saveToFolderPath);
            }
        }
    }
