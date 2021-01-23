    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
    	using (Form2 frm = new Form2(UpdateTextBoxValue)) {
    		frm.ShowDialog();
    	}
    }
    
    public void UpdateTextBoxValue(string value)
    {
    	TextBox1.Text = value;
    }
