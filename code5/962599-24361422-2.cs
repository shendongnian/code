    protected void btnExportPDF_Click(object sender, EventArgs e)
    {
    	GridView1.AllowPaging = false;
    	GridView1.DataBind();
    
    	BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);
    
    	iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(GridView1.Columns.Count);
    	int[] widths = new int[GridView1.Columns.Count];
    	for (int x = 0; x < GridView1.Columns.Count; x++)
    	{
    		widths[x] = (int)GridView1.Columns[x].ItemStyle.Width.Value;
    		string cellText = Server.HtmlDecode(GridView1.HeaderRow.Cells[x].Text);
    
    		//Set Font and Font Color
    		iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
    		font.Color = new Color(GridView1.HeaderStyle.ForeColor);
    		iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(12, cellText, font));
    
    		//Set Header Row BackGround Color
    		cell.BackgroundColor = new Color(GridView1.HeaderStyle.BackColor);
    
    
    		table.AddCell(cell);
    	}
    	table.SetWidths(widths);
    
    	for (int i = 0; i < GridView1.Rows.Count; i++)
    	{
    		if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
    		{
    			for (int j = 0; j < GridView1.Columns.Count; j++)
    			{
    				string cellText = Server.HtmlDecode(GridView1.Rows[i].Cells[j].Text);
    
    				//Set Font and Font Color
    				iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
    				font.Color = new Color(GridView1.RowStyle.ForeColor);
    				iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(12, cellText, font));
    
    				//Set Color of row
    				if (i % 2 == 0)
    				{
    					//Set Row BackGround Color
    					cell.BackgroundColor = new Color(GridView1.RowStyle.BackColor);
    				}
    
    				table.AddCell(cell);
    			}
    		}
    	}
    
    	//Create the PDF Document
    	Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    	PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    	pdfDoc.Open();
    	pdfDoc.Add(table);
    	pdfDoc.Close();
    	Response.ContentType = "application/pdf";
    	Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
    	Response.Cache.SetCacheability(HttpCacheability.NoCache);
    	Response.Write(pdfDoc);
    	Response.End();
    }
