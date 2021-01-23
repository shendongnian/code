    private void btn_Click(object sender, EventArgs e)
    {
        if (sender is Control) { 
            MessageBox.Show(((Control)sender).Tag.ToString()); 
        }
    }
