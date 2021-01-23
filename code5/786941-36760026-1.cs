        private void ExportToPdfDemo()
        {
            try
            {
                Document document = new Document(PageSize.A4);
                // string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\PURCHASE REPORTS\";
                string appPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Sales Report\";
                if (Directory.Exists(appPath) == false)
                {
                    Directory.CreateDirectory(appPath);
                }
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(appPath + "/" + txt_ReferenceNo.Text + ".pdf", FileMode.Create));
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                cb.SetLineWidth(2.0f);   // Make a bit thicker than 1.0 default
                cb.SetGrayStroke(0.95f); // 1 = black, 0 = white
                cb.MoveTo(20, document.Top - 30f);
                cb.LineTo(400, document.Top - 30f);
                cb.Stroke();
                PdfPTable Ttable = new PdfPTable(1);
                float[] widths = new float[] { 1f };
                Ttable.SetWidths(widths);
                PdfPCell numeroCell = new PdfPCell(new Phrase("Reference No: " + txt_ReferenceNo.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase("Date: " + dtpPurchaseDate.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase("Customer Code: " + txt_CustomerCode.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase("Customer Name: " + txt_CustomerName.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase(""));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase(""));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);
                PdfPTable table = new PdfPTable(5);
                widths = new float[] { 1f, 1f, 1f, 1f, 1f };
                table.SetWidths(widths);
                numeroCell = new PdfPCell(new Phrase("Product Code"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase("Product Name"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase("Unit Price"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase("Quantity"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);
                numeroCell = new PdfPCell(new Phrase("Total Price"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);
                PdfPCell cell;
                foreach (DataGridViewRow row in grd_PurchaseList.Rows)
                {
                    cell = new PdfPCell(new Phrase(row.Cells["PurchseProductCode"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(row.Cells["PurchasePName"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(row.Cells["PurchaseQuantity"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(row.Cells["PurchaseUnitPrice"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(row.Cells["PurchaseTotalPrice"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                }
                for (int i = 0; i < 23; i++)
                {
                    cell = new PdfPCell(new Phrase(""));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                }
                cell = new PdfPCell(new Phrase("Tax Amount :"));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);
                double taxAmount = Convert.ToDouble(txt_GrandTotal.Text) - Convert.ToDouble(txt_SubTotal.Text);
                cell = new PdfPCell(new Phrase("" + taxAmount));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);
                for (int i = 0; i < 3; i++)
                {
                    cell = new PdfPCell(new Phrase(""));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                }
                cell = new PdfPCell(new Phrase("Total Amount :"));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(txt_GrandTotal.Text));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);
                //table.SpacingBefore = 20f;
                //table.SpacingAfter = 30f;
                document.Add(Ttable);
                Ttable.SpacingAfter = 40f;
                document.Add(table);
                document.Close();
            }
        }
