            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "excelname.xls"));
            Response.ContentType = "application/ms-excel";
            //which row you dont want in gridview
            GridView5.Columns[0].Visible = false;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView5.AllowPaging = false;
            GridView5.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
