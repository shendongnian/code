                    //Get Attachments
                    Attachment[] atts = oMail.Attachments;
                    int count = atts.Length;
                    //Store Attachments
                    for (int ai = 0; ai < count; ai++)
                    {
                        Attachment att = atts[ai];
                        string attname = String.Format("{0}\\{1}", mailbox, att.Name);
                        att.SaveAs(attname, true);
                    }
