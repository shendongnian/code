    protected void Button1_Clicked(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            //Your logic for OK button
        }
        else
        {
            //Your logic for cancel button
        }
    }
