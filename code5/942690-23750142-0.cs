    public void Update_Click(object sender, EventArgs e)
    {
        using (PccBiometricsHandler.Form1 ShowProgress = new PccBiometricsHandler.Form1())
        {
            menu.Items[2].Enabled = false;
            ShowProgress.ShowDialog();
        }
        updaterAccess();
        menu.Items[2].Enabled = true;
    }
