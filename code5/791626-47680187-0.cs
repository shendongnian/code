                string originalFile = "Original1.pdf";
                string copyOfOriginal = "Re-copia.pdf";
                byte[] bytes = Convert.FromBase64String(archivo);
                System.IO.FileStream stream = new FileStream(originalFile, FileMode.CreateNew);
                System.IO.BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                PdfReader reader1 = new PdfReader(originalFile);
                using (FileStream fs = new FileStream(copyOfOriginal, FileMode.Create, FileAccess.Write, FileShare.None))
                // Creating iTextSharp.text.pdf.PdfStamper object to write
                // Data from iTextSharp.text.pdf.PdfReader object to FileStream object
                using (PdfStamper stamper = new PdfStamper(reader1, fs))
                {
                    int pageCount = reader1.NumberOfPages;
                    // Create New Layer for Watermark
                    PdfLayer layer = new PdfLayer("WatermarkLayer", stamper.Writer);
                    // Loop through each Page
                    for (int i = pageCount; i <= pageCount; i++)
                    {
                        // Getting the Page Size
                        Rectangle rect = reader1.GetPageSize(i);
                        
                        // Get the ContentByte object
                        PdfContentByte cb = stamper.GetUnderContent(i);
                        // Tell the cb that the next commands should be "bound" to this new layer
                        cb.BeginLayer(layer);
                        cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 50);
                        PdfGState gState = new PdfGState();
                        cb.SetGState(gState);
                        string codbartest = codBarras;
                        BarcodePDF417 bcpdf417 = new BarcodePDF417();
                        //Asigna el código de barras en base64 a la propiedad text del objeto..
                        bcpdf417.Text = ASCIIEncoding.ASCII.GetBytes(codbartest);
                        Image imgpdf417 = bcpdf417.GetImage();
                        imgpdf417.SetAbsolutePosition(50, 50);
                        imgpdf417.ScalePercent(100);
                        cb.AddImage(imgpdf417);
                        // Close the layer
                        cb.EndLayer();
                    }[enter image description here][1]
