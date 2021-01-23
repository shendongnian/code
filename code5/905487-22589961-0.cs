    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        ...
        if (checkBox1.Checked)
        {
            lblDynamic.Visible = true;
        }
        else
        {
            lblDynamic.Visible = false;
            
        }
    }
