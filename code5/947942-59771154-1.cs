    using PDFiumSharp;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    public class Program
    {
	    static public void Main(String[] args) 
        { 
	        var renderfoo = new Renderfoo()
	        renderfoo.RenderPDFAsImages(@"C:\Temp\example.pdf", @"C:\temp");
        } 
    }
    public class Renderfoo
    {
    
    public void RenderPDFAsImages(string Inputfile, string OutputFolder)
        {
            string fileName = Path.GetFileNameWithoutExtension(Inputfile);
            using (PDFiumSharp.PdfDocument doc = new PDFiumSharp.PdfDocument(Inputfile))
            {
                for (int i = 0; i < doc.Pages.Count; i++)
                {
                    var page = doc.Pages[i];
                    using (var bitmap = new System.Drawing.Bitmap((int)page.Width, (int)page.Height))
                    {
                        var grahpics = Graphics.FromImage(bitmap);
                        grahpics.Clear(Color.White);
                        page.Render(bitmap);
                        var targetFile = Path.Combine(OutputFolder, fileName + "_" + i + ".png");
                        bitmap.Save(targetFile);
                    }
                }
            }
        }
		
    }
