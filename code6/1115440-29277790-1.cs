                public ActionResult Contingency_Report(List<int> ids)
        {
            MemoryStream workStream = new MemoryStream();
            pdfExport pdf = new pdfExport(ids);
            workStream = pdf.returnPDF();
            workStream.Position = 0;
            var fName = string.Format("Contingency-{0}", DateTime.Now.ToString("s"));
            Session[fName] = workStream;
            return Json(new { success = true, fName }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Download_Report(string fName)
        {
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = fName+".pdf",
                Inline = false,
            };
            var stream = Session[fName] as MemoryStream;
            if (stream == null)
                return new EmptyResult();
            Session[fName] = null;
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }
