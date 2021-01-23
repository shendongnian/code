            CRAXDRT.DatabaseTable T;
            
            for (int i = 1; i <= report1.Database.Tables.Count; i++)
            {
                T = (CRAXDRT.DatabaseTable)report1.Database.Tables[i];
                CRAXDRT.ConnectionProperties cps = T.ConnectionProperties;
                CRAXDRT.ConnectionProperty cp =
                    (CRAXDRT.ConnectionProperty)cps["User ID"];
                cp.Value = "Username" ;
                cp = (CRAXDRT.ConnectionProperty)cps["Password"];
                cp.Value = "Password" ;
                cp = (CRAXDRT.ConnectionProperty)cps["Data Source"];
                cp.Value = "DataSource" ;
                T.SetLogOnInfo("DataSource", "", "Username", "Password");
            }
