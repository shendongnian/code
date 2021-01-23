    using System;
    using System.IO;
    using Microsoft.Office.Interop.Excel;
    
    namespace xlsxToPdf
    {
        class Program
        {
            static void Main(string[] args)
            {
                if(args.Length>0 && Directory.Exists(args[0]))
                {
                    Application app = new Application();
                    Workbook wkb;
                    foreach (string file in Directory.GetFiles(args[0],"*.xlsx"))
                    {
                        wkb = app.Workbooks.Open(file);
                        wkb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, file.Remove(file.Length-4,4)+"pdf");
                        wkb.Close();
                    }
                }
            }
        }
    }
