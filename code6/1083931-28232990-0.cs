    public void ToExcel(DataTable dt, string reportName)
        {
            if (dt.Rows.Count > 0)
            {
                string filename = string.Format("{0}.xls", reportName);
                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
                HtmlForm hf = new HtmlForm();
    
                DataGrid dg = new DataGrid();
    
                dg.DataSource = dt;
                dg.HeaderStyle.BackColor = Color.Tomato;
                dg.HeaderStyle.ForeColor = Color.White;
                dg.BackColor = Color.LightGoldenrodYellow;
                dg.AlternatingItemStyle.BackColor = Color.PaleGoldenrod;
                dg.Font.Name = "Tahoma";
                dg.Font.Size = 10;
                dg.DataBind();
    
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
    
                HttpContext.Current.Response.Charset = "";
                EnableViewState = false;
                Controls.Add(hf);
                hf.Controls.Add(dg);
                hf.RenderControl(htw);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
