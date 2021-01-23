        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                //do something
            }
        }
        protected void validateTheTextBox_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString))
            using (var da = new SqlDataAdapter("SELECT Account Table WHERE Account = @Account", conn))
            {
                da.SelectCommand.Parameters.Add("@Account", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@Account"].Value = args.Value;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
