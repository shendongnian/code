    public void optionCheck(TextBox txt, ref string str)
    {
        if (txt.Text == "0")
        {
            str = "+++";
        }
        else
        {
            str = "---";
       }
       //or:
       str = txt.Text == "0" ? "+++" : "---";
    }
