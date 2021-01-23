    // oh, and btw, don't use double when working with money
    private decimal _sum;
    private void box_Paid_CheckedChanged(object sender, EventArgs e)
    {
        if (box_Paid.Checked == true)
        {
            _sum += 5;
        }
        else
        {
            _sum -= 5;
        }
        
        label_AmountLeft.Text = _sum.ToString();
    }
