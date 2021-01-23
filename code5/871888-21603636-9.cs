     private void tabControl1_Selected(object sender, TabControlEventArgs e) 
     {
        var result = e.TabPage.Controls.OfType<ComboBox>()
                    .Where(x => x.Name.StartsWith("cboFunction"));
        if(result != null)
        {
            ComboBox b = result.ToList().First();
            richTextBox.Text = comboBox1.Text;            
        }
    }
