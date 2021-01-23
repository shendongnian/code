        if (lblMonTotal.Text.Contains(","))
        {
            strmontot = lblMonTotal.Text.Split(',');
        }
        if (lblMonTotal.Text.Contains("."))
        {
            strmontot = lblMonTotal.Text.Split('.');
        }
        else
        {
            strmontot = new string[2] { montot.ToString(), "0" };
        }
        else if (hr != 0)
        {
            lblMonTotal.Text = hr + ".0" + min;
        }
