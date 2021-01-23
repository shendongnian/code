    private bool arePartsChecked;
 
    private List<string> partsList = new List<string>();
    private void saveAdd()
    {
        arePartsChecked = chkParts.Checked; 
        partsList.Clear();
        foreach (ListViewItem item in lvwPartsList.Items)
          partsList.Add(item.Text);
        backgroundWorker.RunWorkerAsync(); // loading bar
        // remove saving code, move it to DoWork event
    }
    private void backgroundWorkerDoWork(object sender, DoWorkEventArgs e)
    {
        DBconnection dbConString = new DBconnection();
        FbConnection dbConnect = new FbConnection(dbConString.getConnectionString()); 
        // part of your code ......
        if ((arePartsChecked) && (partsList.Count > 0))
        {
            foreach (itemList partsList)
            {
                FbCommand myCommand7 = new FbCommand(getPartsQuerryStrings("insEquipMstPart",
                  strDtlequipmentid, item), dbConnect, transaction); //stantiate sql command AND note: item is now a string...!!
                // etc.
            }
            // ...
        } 
        finally
        {
            dbConnect.Close();
        }
    }
