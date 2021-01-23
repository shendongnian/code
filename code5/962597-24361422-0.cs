     			protected void Button1_Click(object sender, EventArgs e)
				{      
					iTextSharp.text.Table table = new iTextSharp.text.Table(gvExport.Columns.Count);
					table.Cellpadding = 2;
					table.Width = 100;
					BindData();
					//Transfer rows from GridView to table
					for (int i = 0; i < gvExport.Columns.Count; i++)
					{
						string cellText = Server.HtmlDecode
												  (gvExport.Columns[i].HeaderText); 
						iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
						cell.BackgroundColor = new Color(System.Drawing
													   .ColorTranslator.FromHtml("#93a31d"));
						table.AddCell(cell);
					}
			 
					for (int i = 0; i < gvExport.Rows.Count; i++)
					{
						if (gvExport.Rows[i].RowType == DataControlRowType.DataRow)
						{
							for (int j = 0; j < gvExport.Columns.Count; j++)
							{
								string cellText = Server.HtmlDecode
												  (gvExport.Rows[i].Cells[j].Text);
								iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
			 
								//Set Color of Alternating row
								if (i % 2 != 0)
								{
									cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#dce0bc"));
								}
								table.AddCell(cell);
							}
						}
					}
			 
					Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
					PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
					pdfDoc.Open();
					pdfDoc.Add(table);
					pdfDoc.Close();
					Response.ContentType = "application/pdf";
					Response.AddHeader("content-disposition", "attachment;" +
												   "filename=GridView.pdf");
					Response.Cache.SetCacheability(HttpCacheability.NoCache);
					Response.Write(pdfDoc);
					Response.End();
				} 
			}
