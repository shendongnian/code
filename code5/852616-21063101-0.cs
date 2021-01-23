    private void AppendValue(string valueToAppend)
    {
        if(remainTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            remainTxt.AppendText(valueToAppend);
        }
        else if (totalTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            totalTxt.AppendText(valueToAppend);
        }
        else if (paidTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            paidTxt.AppendText(valueToAppend);
        }
    }
