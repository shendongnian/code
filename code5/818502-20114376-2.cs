        if (!String.IsNullOrWhitespace(Request.QueryString["SChn"]))
        {
            if (!String.IsNullOrWhitespace(Request.QueryString["PAN"]))
            {
                if (!String.IsNullOrWhitespace(Request.QueryString["Stag"]))
                {
                    if (!String.IsNullOrWhitespace(Request.QueryString["MAC"]))
                    {
                        insertData();
                    }
                }
            }
        }
