    private void cmdClearAll_Click(object sender, EventArgs e)
    {
        //loop in TabPages collection in tabControl1
        foreach (System.Windows.Forms.TabPage tab in tabControl1.TabPages)
        {
            //loop in all controls in looping TabPage
            foreach (Control ctrl in tab.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = string.Empty;
                }
    
                if (ctrl is Label)
                {
                    (ctrl as Label).Text = string.Empty;
                }
    
                if (ctrl is ListBox)
                {
                    (ctrl as ListBox).Items.Clear();
                }
    
                if (ctrl is ComboBox)
                {
                    //(ctrl as ComboBox).SelectedIndex = -1;
                    (ctrl as ComboBox).Items.Clear();
                }
            }
        }
    }
