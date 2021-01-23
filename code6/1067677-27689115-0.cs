    foreach(Control c in Panel1.Controls)
    {
    	var control = Panel2.Controls.AsEnumerable().Where(p => p.name = c.name).select();
    	Textbox txt = control as TextBox;
    	c.Text = txt.Text;
    }
