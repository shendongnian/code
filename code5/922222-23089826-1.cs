    protected void btnGo_Click(object sender, EventArgs e)
    {
        string destinationDrive = cmbDrives.SelectedValue.ToString();
        Process.Start("xcopy", string.Format("/someswitch {0} otherarguments", destinationDrive));
    }
