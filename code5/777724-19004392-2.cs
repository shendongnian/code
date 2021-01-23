    private void CreatePDF()
    {
        string fileName = string.Empty;    
        DateTime fileCreationDatetime = DateTime.Now;    
        fileName = string.Format("{0}.pdf", fileCreationDatetime.ToString(@"yyyyMMdd") + "_" + fileCreationDatetime.ToString(@"HHmmss"));    
        string pdfPath = Server.MapPath(@"~\PDFs\") +   fileName;
    
        using (FileStream msReport = new FileStream(pdfPath, FileMode.Create))
        {
            //step 1
            using (Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 140f, 10f))
            {
                try
                {
                    // step 2
                    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                    pdfWriter.PageEvent = new Common.ITextEvents();
    
                    //open the stream 
                    pdfDoc.Open();
    
                    for (int i = 0; i < 10; i++)
                    {
                        Paragraph para = new Paragraph("Hello world. Checking Header Footer", new Font(Font.FontFamily.HELVETICA, 22));    
                        para.Alignment = Element.ALIGN_CENTER;    
                        pdfDoc.Add(para);    
                        pdfDoc.NewPage();
                    }
                 
                    pdfDoc.Close();    
                }
                catch (Exception ex)
                {
                    //handle exception
                }    
                finally
                { 
                }    
            }    
        }
    }
