    void btnOne_Click(object sender, EventArgs e)
    { 
        this.Controls.OfType<CheckBox>()
                     .Where(c => c.Checked == true)
                     .Select(c => c.Text)
                     .ForEach(text => lstOne.Items.Add(text));
    }
