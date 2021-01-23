    string picloc;
    string new_loc;
    private void UpdBtn_Click(object sender, EventArgs e)
    {
        dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|ALL Files(*.*)|*.*";
        dlg.Title = "Select Thumbnail";
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            // Result();
            picloc = dlg.FileName.ToString();
            pic1.ImageLocation = picloc;
            File.Copy(picloc, new_loc); // new_loc being the new location for the file.
        }
        
    }
