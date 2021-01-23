    if (!String.IsNullOrEmpty(Request.QueryString["SChn"]))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["PAN"]))
                {
                    if (!String.IsNullOrEmpty(Request.QueryString["Stag"]))
                    {
                        if (!String.IsNullOrEmpty(Request.QueryString["MAC"]))
                        {
                            insertData();
                        }
                    }
                }
            }
