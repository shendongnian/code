    using System;
    using Microsoft.Office.Interop.Word;
    
    namespace CSharpConsole
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var application = new ApplicationClass();
                var document = application.Documents.Add();
                document.SaveAs("D:\test.docx");
                application.Quit();
            }
        }
    }
