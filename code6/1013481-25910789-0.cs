            string contentType = "application/pdf";
            Byte[] mybytes = ReportViewer1.LocalReport.Render("PDF", null,
                            out extension, out encoding,
                            out mimeType, out streams, out warnings); //for exporting to PDF  
            using (FileStream fs = File.Create(Server.MapPath("~/Report/") + FileName))
            {
                fs.Write(mybytes, 0, mybytes.Length);
            }
            //Response.ClearHeaders();
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.Clear();
            Response.ContentType = contentType;
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
            Response.WriteFile(Server.MapPath("~/Report/" + FileName));
            Response.Flush();
            //Response.Close();
            //Response.End();   
    }
