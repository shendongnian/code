    // flag when  page renders normally / when you're sending PDF
          private bool _convertToPdf;
    // set _convertToPdf in your BtnSubmit_Click() - I never use AutoEventWireup
          public void ProcessPage(object sender, CommandEventArgs e) {
              _convertToPdf = true;
          }
    
          protected override void Render(HtmlTextWriter writer) {
            if (!_convertToPdf) { base.Render(writer); }
            else {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=thisPage.pdf");
                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb)) {
                    using (var htmlTextWriter = new HtmlTextWriter(sw)) {
                        base.Render(htmlTextWriter);
                        using (var document = new Document()) {
                            var pdfWriter = PdfWriter.GetInstance(document, Response.OutputStream);
                            document.Open();
                            using (var stringReader = new StringReader(sb.ToString())) {
                                XMLWorkerHelper.GetInstance().ParseXHtml(
                                    pdfWriter, document, stringReader
                                );
                            }
                        }
                    }
                }
                Response.End();        
            }
