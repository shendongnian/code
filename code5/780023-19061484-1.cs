        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int itemIndex = Convert.ToInt32(e.CommandArgument);
            Panel childViewPanel = (Panel)DataList1.Items[itemIndex].FindControl("pnlChildView");
            if (childViewPanel != null)
            {
                if (childViewPanel.Visible)
                {
                    DataList childList = (DataList)childViewPanel.FindControl("DataList2");
                    if (childList != null)
                    {
                        int keyValue = (int)DataList1.DataKeys[itemIndex];
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand("SELECT FirstName, LastName FROM dbo.Import_CompanyContact WHERE Company = " + keyValue, con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    childList.DataSource = dr;
                                    childList.DataBind();
                                }
                            }
                        }
                    }
                }
            }
        }
