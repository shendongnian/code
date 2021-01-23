    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (!string.IsNullOrEmpty(dlg.FileName))
            {
                Form2 frm = new Form2(dlg.FileName);
                frm.Show();
            }
        }
    }
