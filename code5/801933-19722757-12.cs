    using System.Reflection;
    using Microsoft.Office.Interop.Word;
    using System.Runtime.InteropServices;
    
    namespace Interop1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application application = null;
                try
                {
                    application = new Application();
                    var document = application.Documents.Add();
                    var paragraph = document.Paragraphs.Add();
                    paragraph.Range.Text = "some text";
                    string filename = GetFullName();
                    application.ActiveDocument.SaveAs(filename, WdSaveFormat.wdFormatDocument);
                    document.Close();
                
                }
                finally
                {
                    if (application != null)
                    {
                        application.Quit();
                        Marshal.FinalReleaseComObject(application);
                    }
                }
            }
        }
    }
