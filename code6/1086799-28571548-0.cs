        public HttpResponseBase HitlijstNaarPdf(int? AID_Hitlijst = 0)
        {
            SelectPeriode(AID_Hitlijst);
            var model = new HitlijstModel();
            GetHitlijstSettings();
            string sHtmlInhoud = ViewRenderer.RenderView("Hitlijst", model, ControllerContext);
            string fileName = "Hitlijst_" + AID_Hitlijst.ToString() + ".pdf";
            return CreatePDF(sHtmlInhoud, fileName);
        }
        private HttpResponseBase CreatePDF(string html, string fileName)
        {
            string convertingTool = Server.MapPath("~/bin/wkhtmltopdf.exe ");
            ProcessStartInfo psi = new ProcessStartInfo(convertingTool);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
            Process myProcess = Process.Start(psi);
            myProcess.WaitForExit();
            myProcess.Close();
            string fullFileName = Server.MapPath("~/Documenten/" + fileName);
            if (!System.IO.File.Exists(fullFileName))
            {
                Document pdfDocument = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(pdfDocument, new FileStream(fullFileName, FileMode.Create));
                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
                pdfDocument.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDocument, new StringReader(html));
                pdfDocument.Close();
            }
            Response.Clear();
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(fullFileName); 
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(buffer);
            return Response;
        }
