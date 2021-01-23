    void wbViewWorkflowData_KeyDown(object sender, KeyEventArgs e)
            {
                WorkbookView wbView = (WorkbookView)sender;
    
                if (e.Control && e.KeyCode == Keys.V)
                {
                    wbView.GetLock();
                    try
                    {
                        e.SuppressKeyPress = true;
                        wbView.PasteSpecial(PasteType.Values, PasteOperation.None, false, false);
                        //Additional stuff here.
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        wbView.ReleaseLock();
                    }
                }
            }
