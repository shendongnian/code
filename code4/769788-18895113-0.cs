    using Word = Microsoft.Office.Interop.Word;
    using System.Reflection;
    using Microsoft.Office.Interop.Word;
     protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc";
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                Word.Paragraph oParag;
                oParag = oDoc.Content.Paragraphs.Add(ref oMissing);
                oParag.Range.Text = "Return Order";
                oParag.Range.Font.Bold = 2;
                oParag.Format.SpaceAfter = 30;
                oParag.Range.InsertParagraphAfter();
                Word.Paragraph oPara1;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara1.Range.Text = "Date: " + txtDate.Text;
                oPara1.Range.Font.Bold = 0;
                oPara1.Format.SpaceAfter = 24;
                oPara1.Range.InsertParagraphAfter();
                Word.Paragraph oPara2;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara2.Range.Text = "PO Number: " + txtPONumber.Text;
                oPara2.Range.Font.Bold = 0;
                oPara2.Format.SpaceAfter = 24;
                oPara2.Range.InsertParagraphAfter();
                Word.Paragraph oPara3;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara3.Range.Text = "Invoice Number: " + txtnvoiceNo.Text;
                oPara3.Range.Font.Bold = 0;
                oPara3.Format.SpaceAfter = 24;
                oPara3.Range.InsertParagraphAfter();
                Word.Paragraph oPara4;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara4.Range.Text = "Company Name or Dealer Name: " + txtCompanyName.Text;
                oPara4.Range.Font.Bold = 0;
                oPara4.Format.SpaceAfter = 24;
                oPara4.Range.InsertParagraphAfter();
                Word.Paragraph oPara5;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara5 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara5.Range.Text = "Order Number: " + txtOrderNo.Text;
                oPara5.Range.Font.Bold = 0;
                oPara5.Format.SpaceAfter = 24;
                oPara5.Range.InsertParagraphAfter();
                Word.Paragraph oPara6;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara6 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara6.Range.Text = "Contact Person to Return: " + txtReturnPerson.Text;
                oPara6.Range.Font.Bold = 0;
                oPara6.Format.SpaceAfter = 24;
                oPara6.Range.InsertParagraphAfter();
                Word.Paragraph oPara7;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara7 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara7.Range.Text = "Email: " + txtEmail.Text;
                oPara7.Range.Font.Bold = 0;
                oPara7.Format.SpaceAfter = 24;
                oPara7.Range.InsertParagraphAfter();
                //inserting table
                Word.Table oTable;
                int iTblRowCount = gvReturnOrders.Rows.Count + 1;
                Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable = oDoc.Tables.Add(wrdRng, iTblRowCount, 3, ref oMissing, ref oMissing);
                oTable.Range.ParagraphFormat.SpaceAfter = 6;
                oTable.Rows[1].Cells[1].Range.Text = "Line Item";
                oTable.Rows[1].Cells[2].Range.Text = "Return Quantity";
                oTable.Rows[1].Cells[3].Range.Text = "Product Description";
                oTable.Rows[1].Cells[1].Range.Bold = 1;
                oTable.Rows[1].Cells[2].Range.Bold = 1;
                oTable.Rows[1].Cells[3].Range.Bold = 1;
                int iRowCount, iCount = 2;
                int rowIndex = 0;
                for (iRowCount = 1; iRowCount <= gvReturnOrders.Rows.Count; iRowCount++)
                {
                    TextBox txtboxLineItems = (TextBox)gvReturnOrders.Rows[rowIndex].Cells[1].FindControl("txtLineItem");
                    TextBox txtBoxQty = (TextBox)gvReturnOrders.Rows[rowIndex].Cells[2].FindControl("txtReturnQuantity");
                    TextBox txtBoxproductDescription = (TextBox)gvReturnOrders.Rows[rowIndex].Cells[3].FindControl("txtProductDescription");
                    oTable.Rows[iCount].Cells[1].Range.Text = txtboxLineItems.Text;
                    oTable.Rows[iCount].Cells[2].Range.Text = txtBoxQty.Text;
                    oTable.Rows[iCount].Cells[3].Range.Text = txtBoxproductDescription.Text;
                    iCount++;
                    rowIndex++;
                }
                //var myUniqueFileName = string.Format(@"{0}.doc", Guid.NewGuid()); // for Unique Id
                string fileName = "C:\\ReturnOrder.doc";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    oDoc.SaveAs2("C:\\ReturnOrder.doc");
                    lblMsg.Visible = true;
                    lblMsg.Text = "Successful";
                }
                else
                {
                    oDoc.SaveAs2("C:\\ReturnOrder.doc");
                    lblMsg.Visible = true;
                    lblMsg.Text = "Successful";
                }
                oDoc.Close();
                oWord.Quit();
            }
            catch (Exception ex)
            {
            }
        }
