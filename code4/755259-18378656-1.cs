    String strSelectUserListBuilder = @"<html><body>
                                    <h1>My First Heading</h1>
                                    <p>My first paragraph.</p>
                                </body>
                            </html>";
    
    String htmlText = strSelectUserListBuilder.ToString();
    CreatePDFFromHTMLFile(htmlText , pdfFileName);
    public void CreatePDFFromHTMLFile(string HtmlStream, string FileName)
     {
         try
         {
             object TargetFile = FileName;
             string ModifiedFileName = string.Empty;
             string FinalFileName = string.Empty;
    
             /* To add a Password to PDF -test */
             TestPDF.HtmlToPdfBuilder builder = new TestPDF.HtmlToPdfBuilder(iTextSharp.text.PageSize.A4);
             TestPDF.HtmlPdfPage first = builder.AddPage();
             first.AppendHtml(HtmlStream);
             byte[] file = builder.RenderPdf();
             File.WriteAllBytes(TargetFile.ToString(), file);
    
             iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(TargetFile.ToString());
             ModifiedFileName = TargetFile.ToString();
             ModifiedFileName = ModifiedFileName.Insert(ModifiedFileName.Length - 4, "1");
    
             string password = "password";
             iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, new FileStream(ModifiedFileName, FileMode.Append), iTextSharp.text.pdf.PdfWriter.STRENGTH128BITS, password, "", iTextSharp.text.pdf.PdfWriter.AllowPrinting);ss
             reader.Close();
             if (File.Exists(TargetFile.ToString()))
                 File.Delete(TargetFile.ToString());
             FinalFileName = ModifiedFileName.Remove(ModifiedFileName.Length - 5, 1);
             File.Copy(ModifiedFileName, FinalFileName);
             if (File.Exists(ModifiedFileName))
                 File.Delete(ModifiedFileName);
    
         }
         catch (Exception ex)
         {
             throw ex;
         }
     }
