    private void field_Click(object sender, EventArgs e)
    {
        string[] sSplitTag = ((Button)sender).Tag.ToString().Split('|');
        int i = Convert.ToInt32(sSplitTag[0]);
        int j = Convert.ToInt32(sSplitTag[1]);
    }
