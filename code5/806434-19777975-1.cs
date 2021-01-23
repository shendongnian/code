    using Outlook = Microsoft.Office.Interop.Outlook; 
    public void MoveMyEmails()
        {
            //set up variables
            Outlook.Application oApp = null;
            Outlook.MAPIFolder oSource = null;
            Outlook.MAPIFolder oTarget = null;
            try
            {
                //instantiate variables
                oApp = new Outlook.Application();
                oSource = oApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
                oTarget = oApp.Session.Folders["Archive"];
                //loop through the folders items
                for (int i = oSource.Items.Count; i > 0; i--)
                {
                    move the item
                    oSource.Items[i].Move(oTarget);
                }
            }
            catch (Exception e)
            {
                //handle exception
            }
            //release objects
            if (oTarget != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oTarget);
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            if (oSource != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSource);
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            if (oApp != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oApp);
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
