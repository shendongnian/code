    private void btn_Click(object sender, EventArgs e)
    {
        if (sender.GetType() == typeof(Control) { 
            MessageBox.Show(((Control)sender).Tag.ToString()); 
        }
    }
