    private void btnback_Click(object sender, EventArgs e)
    {
        if (remainTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            RemoveLast(remainTxt);
        }
        else if (totalTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            RemoveLast(totalTxt);
        }
        else if (paidTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            RemoveLast(paidTxt);
        }
    }
