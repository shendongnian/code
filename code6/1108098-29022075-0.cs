    private void cbxPIN_SelectedIndexChanged(object sender, EventArgs e)
    {
        int pines = Convert.ToInt32(cbxPIN.SelectedItem.ToString());
        TextBox textBox;
        for (int i = 1; i < pines; i++)
        {
            // get the control from the form's controls collection by the control name
            textBox = this.Controls["textbox" + pines.ToString()] As TextBox
            textBox.Visible = true;
        }
