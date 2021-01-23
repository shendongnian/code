    bool spouseActive;
    public Client()
    {
        // table_assets
        assetsAdapter = new DBAdapter(database.clientAssets);
        assetsAdapter.ConstructAdaptor(null, " cID = " + clientID.ToString());
        table_assets.DataSource = (DataTable)assetsAdapter.ReturnTable();
        table_assets.EditingControlShowing += table_assets_EditingControlShowing;
    }
    private void table_assets_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox)
        {
            ComboBox cbMyComboBox = e.Control as ComboBox;
            if (spouseActive == true)
            {
               cbMyComboBox.Items.Add("<spouse>");     
               cbMyComboBox.Items.Add("Joint");
               Debug.WriteLine("added");
            }
            else
            {  
               cbMyComboBox.Items.Remove("<spouse>");       
               cbMyComboBox.Items.Remove("Joint");
               Debug.WriteLine("removed");
            }
        }
    }
