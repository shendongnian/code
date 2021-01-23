    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.Office.Interop.Word;
    using System.Windows.Forms;
    class Program
    {
        [STAThread]
        public static void Main()
        {
            var file = new FileInfo("input.html");
            Microsoft.Office.Interop.Word.Application app 
                = new Microsoft.Office.Interop.Word.Application();
            try
            {
                app.Visible = true;
                object missing = Missing.Value;
                object visible = true;
                _Document doc = app.Documents.Add(ref missing,
                         ref missing,
                         ref missing,
                         ref visible);
                var bookMark = doc.Words.First.Bookmarks.Add("entry");
                bookMark.Range.InsertFile(file.FullName);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                app.Quit();
            }
        }
    }
