    foreach (Control c in Page.Controls)
        {
                if (c.CssClass == "myClass")
                {
                    c.Visible=false;
                }
        }
