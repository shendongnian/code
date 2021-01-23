    String FileName = "FileName.xls";
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", FileName));
                Response.ContentType = "application/ms-excel";
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                Response.Write(stringWriter.ToString());
                Response.End();
