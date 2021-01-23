    private void SRcmb_tier1_TextChanged(object sender, EventArgs e)
    {
        Boolean found = false;
    
        for (int i = 0; i < SRtier1.Length; i++)
        {
            if (SRcmb_tier1.Text == SRtier1[i])
            {
                found = true;
                break;
            }
        }
    
        if (!found)
           MessageBox.Show("Please select one of the options provided.");
    }
