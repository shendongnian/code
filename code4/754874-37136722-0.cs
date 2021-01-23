            Response.Clear();
            Response.Buffer = true;
            string filename = "GridViewExport_" + DateTime.Now.ToString() + ".xls";
            Response.AddHeader("content-disposition",
            "attachment;filename=" + filename);
            Response.Charset = String.Empty;
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView3.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.End();
           // Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
