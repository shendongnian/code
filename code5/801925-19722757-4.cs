    using System.Reflection;
    using Microsoft.Office.Interop.Word;
    
    namespace Interop1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var application = new Application();
                var document = application.Documents.Add();
                var paragraph = document.Paragraphs.Add();
                paragraph.Range.Text = "some text";
    
                string filename = GetFullName();
                application.ActiveDocument.SaveAs(filename, WdSaveFormat.wdFormatDocument);
                document.Close();
            }
        }
    }
