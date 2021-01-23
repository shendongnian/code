    using (SqlConnection con = new SqlConnection(YOUR_CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID, txtname, txtcitycode from YOUR_TABLE", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DropDownList1.DataTextField = "txtname";
                    DropDownList1.DataValueField = "txtcitycode";
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataBind();
                }
            }
