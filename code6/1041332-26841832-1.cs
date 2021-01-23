    public void btnAccessEmail_Click(object sender, EventArgs e)
    {
        Microsoft.Office.Interop.Outlook.Application myApp = new Microsoft.Office.Interop.Outlook.ApplicationClass();
        Microsoft.Office.Interop.Outlook.NameSpace mapiNameSpace = myApp.GetNamespace("MAPI");
        Microsoft.Office.Interop.Outlook.MAPIFolder myInbox = mapiNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
        Form1 obj = new Form1();
        int xlrow = 3;
        Excel.Application app = new Excel.Application();
        Excel.Workbook workbook = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        Excel.Worksheet worksheet = (Worksheet)workbook.Worksheets[1];
        
        worksheet.Cells[1, 1] = "DATE: "+DateTime.Today.ToLongDateString();
        worksheet.Cells[1, 2] = "TIME: " + DateTime.Now.ToLongTimeString();
        worksheet.Cells[2, 1] = "S.No";
        worksheet.Cells[2, 2] = "Date-Time";
        worksheet.Cells[2, 3] = "Sender Mail Id";
        worksheet.Cells[2, 4] = "Subject";
        worksheet.Cells[2, 5] = "Content";
        worksheet.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
        //range.Interior.Color = XlRgbColor.rgbCadetBlue;
        //range.Font.Color = XlRgbColor.rgbWhite;
        //range.Font.Bold = true;
        //range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
       // ArrayList cdata = new ArrayList();
        int mCount = myInbox.Items.Count;
       
        if (mCount > 0)
        {
            
            
            label2.Text = mCount.ToString();
            for (int j = 1; j <= mCount; j++)
            {
                if (((Microsoft.Office.Interop.Outlook.MailItem) myInbox.Items[j]).SenderEmailAddress.Contains("ramkumar"))
                {
                    var outlookXcell = ((Microsoft.Office.Interop.Outlook.MailItem) myInbox.Items[j]);
                    var mailSub = outlookXcell.Subject;
                    var mailcontent = outlookXcell.Body;
                    var senderemailid = outlookXcell.SenderEmailAddress;
                    var dtime = outlookXcell.CreationTime.ToString();
                    //  var sendernm = outlookXcell.SenderName;
                    //obj.mailtoXcel(mailcontent, sendernm, senderemailid, dtime);
                    worksheet.Cells[xlrow, 1] = j;
                    worksheet.Cells[xlrow, 2] = dtime;
                    worksheet.Cells[xlrow, 3] = senderemailid;
                    worksheet.Cells[xlrow, 4] = mailSub;
                    worksheet.Cells[xlrow, 5] = mailcontent;
                    worksheet.Cells.WrapText = true;
                    xlrow++;
                }
            }
            app.Visible = true;
            String sTemplatePath;
            sTemplatePath = System.AppDomain.CurrentDomain.BaseDirectory;
            workbook.SaveAs(sTemplatePath+"outlook Xcell"+".xls");//, Excel.XlFileFormat.xlXMLSpreadsheet);//, Type.Missing, Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            
            workbook.Close();
        }
    }
