    private void myCombo1_TextUpdate(object sender, EventArgs e)
    {
        foreach (var item in myCombo1.Items.Cast<string>().ToList())
        {
            myCombo1.Items.Remove(item);
        }
        foreach (string item in myCombo1.AutoCompleteCustomSource.Cast<string>().Where(s => s.Contains(myCombo1.Text)).ToList())
        {
            myCombo1.Items.Add(item);
        }
    }
    
