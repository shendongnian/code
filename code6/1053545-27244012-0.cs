    int mCount = myInbox.Items.Count;
         for (int a = 1; a < mCount; a++)
                {
                   var itemn = (Microsoft.Office.Interop.Outlook.MailItem)myInbox.Items[a];
                   
                    if (itemn.CreationTime >= fd && itemn.CreationTime < td)
                    {
                        string subject = itemn.Subject;
                        DateTime reciv = itemn.CreationTime;
                        var mContent = itemn.Body;
                        var senderId = itemn.SenderEmailAddress;
                        worksheet.Cells[xlrow, 2] = reciv;
                        worksheet.Cells[xlrow, 3] = senderId;
                        worksheet.Cells[xlrow, 4] = subject + worksheet.Cells.WrapText;
                        worksheet.Cells[xlrow, 5] = mContent + worksheet.Cells.WrapText;
                        worksheet.Cells.WrapText = true;
                        xlrow++;
                    }
                    
                }
