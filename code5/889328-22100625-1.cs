    private void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            rtxtView.Text = File.ReadAllText(GlobalVars.strLogPath);
            File.WriteAllText(GlobalVars.strLogPath, String.Empty);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);               
        }
    }
