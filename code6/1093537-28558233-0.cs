        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr GetStockObject(int fnObject);
        private static string stringToPrint;
        static void Main(string[] args)
        {
            PrintDocument doc = new PrintDocument();
            ReadFile(doc);
            doc.PrintPage += doc_PrintPage;
            doc.Print();
        }
        
        private static void ReadFile(PrintDocument printDocument1)
        {
            string docName = "Test.txt";
            string docPath = @"c:\";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                stringToPrint = reader.ReadToEnd();
            }
        }
        static void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            // Sets the value of charactersOnPage to the number of characters  
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, Font.FromHfont(GetStockObject(0)),
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);
            // Draws the string within the bounds of the page
            e.Graphics.DrawString(stringToPrint, Font.FromHfont(GetStockObject(0)), Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);
            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);
            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
        }
