    //string folderPath = "C:\\PDFs\\";
                //if (!Directory.Exists(folderPath))
                //{
                //    Directory.CreateDirectory(folderPath);
                //}
                //using (FileStream stream = new FileStream(folderPath + "CON" +             txtContractID.Text + "CID" + txtCustomerID.Text + "INV" + txtInvoiceNo.Text + ".pdf", FileMode.Create))
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "PDF|*.pdf";
                dlg.FilterIndex = 0;
                string fileName = string.Format("CID{0}CON{1}INV{2}.pdf",   txtCustomerID.Text, txtContractID.Text, txtInvoiceNo.Text);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    File.WriteAllText(Name, "test");
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                        //PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
