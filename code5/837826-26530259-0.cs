         public void buildPDFMemoSignature(string DocName, BuildableDoc docBuild)
         {   
            using (var ms = new MemoryStream())
            {
            var doc = new Document(PageSize.A4, 20f, 10f, 30f, 0f);
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();
                try
                {
                  // add stuff to your PDF
                 // Signature is added here ***************
                 PdfFormField field = PdfFormField.CreateSignature(writer);
      field.SetWidget(new iTextSharp.text.Rectangle(190, 730, 440, 650), PdfAnnotation.HIGHLIGHT_NONE);
                        //Rectangle(float llx, float lly, float urx, float ury) 
                        field.FieldName = "mySig";
                        field.Flags = PdfAnnotation.FLAGS_PRINT;
                        field.SetPage();
                        field.MKBorderColor = BaseColor.BLACK;
                        field.MKBackgroundColor = BaseColor.WHITE;
                        PdfAppearance tp = PdfAppearance.CreateAppearance(writer, 72, 48);
                        tp.Rectangle(0.5f, 0.5f, 71.5f, 47.5f);
                        tp.Stroke();
                        field.SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, tp);
                        writer.AddAnnotation(field); 
                        }
                        catch (Exception ex)
                        {  
                          //exceptions                   
                        }
                        finally
                        {
                            doc.Close();
                        }  
     }
