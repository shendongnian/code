     object oMissing = System.Reflection.Missing.Value;
     object oEndOfDoc = "\\endofdoc"; 
     Microsoft.Office.Interop.Word._Application objWord;
     Microsoft.Office.Interop.Word._Document objDoc;
     objWord = new Microsoft.Office.Interop.Word.Application();
     objWord.Visible = true;
    objDoc = objWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
           
            int i = 0;
            int j = 0;
            Microsoft.Office.Interop.Word.Table objTable;
            Microsoft.Office.Interop.Word.Range wrdRng = objDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        
            string strText;
                        
            objTable = objDoc.Tables.Add(wrdRng, 4, 2, ref oMissing, ref oMissing);
            objTable.Range.ParagraphFormat.SpaceAfter = 7;
            strText = "ABC Company";
            objTable.Rows[1].Range.Text = strText;
            objTable.Rows[1].Range.Font.Bold = 1;
            objTable.Rows[1].Range.Font.Size = 24;
            objTable.Rows[1].Range.Font.Position = 1;
            objTable.Rows[1].Range.Font.Name = "Times New Roman";
            objTable.Rows[1].Cells[1].Merge(objTable.Rows[1].Cells[2]);
            objTable.Cell(1,1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                       
            objTable.Rows[2].Range.Font.Italic = 1;
            objTable.Rows[2].Range.Font.Size = 14;
            objTable.Cell(2, 1).Range.Text = "Item Name";
            objTable.Cell(2, 2).Range.Text = "Price";
            objTable.Cell(2, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            objTable.Cell(2, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            
            for (i = 3; i <= 4; i++)
            {
               // objTable.Cell(1, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            
               
                objTable.Rows[i].Range.Font.Bold = 0;
                objTable.Rows[i].Range.Font.Italic = 0;
                objTable.Rows[i].Range.Font.Size = 12;
                for (j = 1; j <= 2; j++)
                {
                    if (j == 1)
                        objTable.Cell(i, j).Range.Text = "Item " + (i - 1);
                    else
                        objTable.Cell(i, j).Range.Text = "Price of " + (i - 1);
                }
            }
            try
            {
                objTable.Borders.Shadow = true;
                objTable.Borders.Shadow = true;
            }
            catch
            {
            }
            
        }
