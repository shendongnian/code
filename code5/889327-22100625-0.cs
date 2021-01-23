     #region Clear Log
    //clear the log file and display it on the rich text box
    private void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            StreamReader read = new StreamReader(GlobalVars.strLogPath);
            str = read.ReadToEnd();
            rtxtView.Text = str;
            read.Close();
            File.WriteAllText(GlobalVars.strLogPath, String.Empty);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);               
        }
    }
