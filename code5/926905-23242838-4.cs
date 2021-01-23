    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Printing;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Xps.Packaging;
    
    namespace ConsoleApplication
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                PrintDialog dlg = new PrintDialog();
                XpsDocument xpsDoc = new XpsDocument(@"C:\DATA\personal\go\test.xps", System.IO.FileAccess.Read);
                dlg.PrintDocument(xpsDoc.GetFixedDocumentSequence().DocumentPaginator, "Document title");
     
            }
        }
    }
