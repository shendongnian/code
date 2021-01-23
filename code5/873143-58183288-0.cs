    protected void ImgExcel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=AddGoodsDetails_" + DateTime.Now + ".xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvView_2.RenderControl(htmlWrite);
        Response.Write("<head><style> td {mso-number-format:\\@;} </style></head><body>");
        Response.Write(stringWrite.ToString());
        Response.End();
    }
