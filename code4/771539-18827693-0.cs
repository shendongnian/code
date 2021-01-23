    if (PlaceHolder1.HasControls())
    {
        foreach (Control uc in PlaceHolder1.Controls)
        {
            if (uc is Spinner)
            {
                Label1.Text += ((Spinner)uc).Name + "<br />";
            }
        }
    }
