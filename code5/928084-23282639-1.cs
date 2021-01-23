    private void btn_upload_Click(object sender, EventArgs e)
    {
        OpenFileDialog op1 = new OpenFileDialog();
        op1.Multiselect = true;
        op1.FileOk += openFileDialog1_FileOk;   // Event handler
        op1.ShowDialog();
        // etc
     }
    void openFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
        OpenFileDialog dlg = sender as OpenFileDialog;
        if (5 < dlg.FileNames.Length)
        {
            MessageBox.Show("Too Many Files");
            e.Cancel = true;
        }
    }
