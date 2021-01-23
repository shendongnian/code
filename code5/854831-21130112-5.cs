    private void OpenFileDialogButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            Button btn = sender as Button; //Get the Button that was clicked
            string souborFilename = openFileDialog1.FileName;
            this.Controls.Find((string)btn.Tag), true )[0].Text = souborFilename; //Find textbox that matches stored name
                                                                                 //since method returns an array you will
                                                                                 //have to access it threw an index.
        }
    }
