	Response.Clear();
	Response.ClearContent();
	Response.ClearHeaders();
	Response.Charset = string.Empty;
	Response.ContentType = "application/pdf";
	Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
	Response.Cache.SetCacheability(HttpCacheability.NoCache);
	Page.Response.Buffer = false;
	using (StringWriter sw = new StringWriter())
	{
		using (HtmlTextWriter hw = new HtmlTextWriter(sw))
		{
			GridView1.AllowPaging = false;
			GridView1.ShowHeader = true;
			this.bindGV();
			GridView1.RenderControl(hw);
			using (StringReader sr = new StringReader(sw.ToString()))
			{
				Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
				HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
				MemoryStream ms = new MemoryStream();
				PdfWriter.GetInstance(pdfDoc, ms);
				pdfDoc.Open();
				htmlparser.Parse(sr);
				pdfDoc.Close();
				byte[] bytes = ms.ToArray();
				Response.AddHeader("Content-Length", bytes.Length.ToString());
				Response.BinaryWrite(bytes);
				Response.Close();
			}
		}
	}
