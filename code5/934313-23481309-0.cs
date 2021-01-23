    private string getctl(Control master)
    {
        string txt = "";
        foreach (Control child in master.Controls)
        {
            txt += "|" + child.ClientID.ToString() + " - " + child.GetType().ToString();
            if (child.HasControls())
            {
                txt += getctl(child);
            }
        }
        return txt;
    }
