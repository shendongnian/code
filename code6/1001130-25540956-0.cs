    void dgvDemo_EditingControlShowing(object sender,
    DataGridViewEditingControlShowingEventArgs e)
    {
	TextBox txt = e.Control as TextBox;
	if (txt != null)
	 {
		txt.KeyPress += new
       KeyPressEventHandler(txt_KeyPress);
	 }
    }
    void txt_KeyPress(object sender, KeyPressEventArgs e)
    {
	 MessageBox.Show(e.KeyChar.ToString());
    }
