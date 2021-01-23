    using (DataTable dt = new DataTable())
    {
        //Set AutoGenerateColumns False
        dtGrdAccounts.AutoGenerateColumns = false;
        //Fetch the data.
        sda.Fill(dt);
        //Set Columns Count
        dtGrdAccounts.ColumnCount = 3;
        //Add Columns
        dtGrdAccounts.Columns[0].Name = "AccountID";
        dtGrdAccounts.Columns[0].HeaderText = "Id";
        dtGrdAccounts.Columns[0].DataPropertyName = "AccID";
        dtGrdAccounts.Columns[1].HeaderText = "Account name";
        dtGrdAccounts.Columns[1].Name = "Account name";
        dtGrdAccounts.Columns[1].DataPropertyName = "AccName";
        dtGrdAccounts.Columns[2].Name = "AccountNumber";
        dtGrdAccounts.Columns[2].HeaderText = "Account number";
        dtGrdAccounts.Columns[2].DataPropertyName = "AccNumber";
        dtGrdAccounts.DataSource = dt;
    }
