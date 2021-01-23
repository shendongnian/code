    public static List<string> getEmailAttachments(string emailID, System.Data.DataTable emails)
        {
            List<string> allAttachments;
            //System.Data.DataTable oTbl = new DataTable();
            try
            {
                System.Diagnostics.Debugger.Break();
                var results = from myRow in emails.AsEnumerable()
                              where myRow.Field<string>("itemID") == emailID
                              select myRow;
                System.Diagnostics.Debug.Print("attachments");
                foreach (DataRow myRow in results)
                {
                    System.Diagnostics.Debug.Print(myRow.Field<string>("attachmentsPath"));
                    allAttachments.Add(myRow.Field<string>("attachmentsPath"));
                    //DataTable dt = (DataTable)myRow["attachmentsPath"];
                    //DataTable oTbl = dt.Clone();
                    //DataRow[] orderRows = dt.Select("CustomerID = 2");
                    //foreach (DataRow dr in orderRows)
                    //{
                    //    oTbl.ImportRow(dr);
                    //}
                    // myTable.ImportRow(dr);
                    //oTbl.Rows.Add(myRow);
                    //oTbl.ImportRow(myRow);
                }
                //return allAttachments;
            }
            catch (Exception ex)
            {
                logBuilder("common.getEmailAttachments", "Exception", "", ex.Message, "");
                allAttachments= new List<string>();
            }
            return allAttachments;
        }
