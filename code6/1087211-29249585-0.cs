    private void BindDropdownlist()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString))
                {
                    tempUsertype = Convert.ToString(Session["UserType"]);
                    if (tempUsertype != string.Empty)
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand((tempUsertype == "0" ? "Select * from tbl_ngoname" : "Select * from tbl_ngoname where id in (Select NgoId from tbl_User where username=@username)"), conn))
                        {
                            cmd.Parameters.AddWithValue("@username", Convert.ToString(Session["User"]));
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            ddlngonameselect.DataValueField = ds.Tables[0].Columns["Id"].ToString();
                            ddlngonameselect.DataTextField = ds.Tables[0].Columns["ngo_name"].ToString();
                            ddlngonameselect.DataSource = ds.Tables[0];
                            ddlngonameselect.SelectedIndex = 0;
                            if (Session["UserType"] == "1" || Session["UserType"] == "2")
                            {
                                ddlngonameselect.Enabled = false;
                            }
                            else
                            {
                                ddlngonameselect.Items.Insert(0, new ListItem() { Text = "--Select NGO--", Value = "0" });
                                ddlngonameselect.Enabled = true;
                            }
                            ddlngonameselect.DataBind();
                        }
                    }
                    else
                    {
                        Response.Write("Some error");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
