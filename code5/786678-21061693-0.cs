    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    
    class Program {
        [STAThread]
        static int Main(string[] args) {
            var app = new Excel.Application();
            try {
                if (args.Length != 2) throw new Exception("Usage: Convert inputfile outputfile");
                var book = app.Workbooks.OpenXML(args[0]);
                System.IO.File.Delete(args[1]);
                book.SaveAs(args[1], FileFormat: Excel.XlFileFormat.xlExcel8);
                app.Quit();
                return 0;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                app.Quit();
                return -1;
            }
        }
    }
