    private void btnPlus_Click(object sender, EventArgs e)
    {
        Double v = 0;
        if ( Double.TryParse(txtDisplay.Text.Trim(), out v)
        {
            total1 = total1 + v;
            txtDisplay.Clear();
        }
        else
        {
            // Invalid value
        }
        
    }
