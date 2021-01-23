    using System;
    using Visio = Microsoft.Office.Interop.Visio;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var app = new Visio.Application();
                var doc = app.Documents.Open(args[0]);
                var page = doc.Pages[1];
                foreach (Visio.Shape shp in page.Shapes)
                    Console.WriteLine("shape #{0}: text: '{1}'", shp.ID, shp.Text);
                foreach (Visio.Connect conn in page.Connects)
                    Console.WriteLine("connector: #{0} -> #{1}", conn.FromSheet.ID, conn.ToSheet.ID);
                app.Quit();
            }
        }
    }
