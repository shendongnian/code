    private void cbxPIN_SelectedIndexChanged(object sender, EventArgs e)
    {
        int pines = Convert.ToInt32(cbxPIN.SelectedItem.ToString());
        if (pines >= 1)
            textbox1.Visible = true;
        if (pines >= 2)
            textbox2.Visible = true;
        ...
        if (pines >= n)
            textboxn.Visible = true;
    }
