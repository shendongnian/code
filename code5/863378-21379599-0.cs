    protected void ExportToPdf(DataTable dt)
                {
                    GridView GridView1 = new GridView();
                    GridView1.ShowHeaderWhenEmpty = true;
                    GridView1.AllowPaging = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + "ggggggggg" + ".pdf");
        
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
        
        
                    GridView1.AllowPaging = false;
                    GridView1.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    GridView1.FooterRow.ForeColor = System.Drawing.Color.Black;
        
                    GridView1.HeaderRow.Style.Add("font-Color", "Black");
                    GridView1.HeaderRow.Style.Add("font-size", "13px");
                    GridView1.HeaderRow.Style.Add("text-decoration", "none");
                    GridView1.HeaderRow.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        
                    GridView1.Style.Add("font-Color", "Black");
                    GridView1.Style.Add("text-decoration", "none");
                    GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                    GridView1.Style.Add("font-size", "11px");
                    GridView1.ForeColor = System.Drawing.Color.Black;
        
                    GridView1.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
                    pdfDoc.Open();
        
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    HttpContext.Current.Response.Write(pdfDoc);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
