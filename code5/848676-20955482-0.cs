    protected void gvVehicle_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow gvr in gvVehicleTEMP.Rows)
            {
                DropDownList ddlLocation = ((DropDownList)gvr.FindControl("ddlLocation"));
                conn.Close();
                conn.Open();
                SqlCommand cmdLocationNames = new SqlCommand("SELECT Name FROM Billers WHERE Store = '" + 1 + "' ORDER BY Name ASC", conn);
                List<string> internalLocationsList = new List<string>();
                using (SqlDataReader reader = cmdLocationNames.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string interlocations = reader.GetString(0);
                        internalLocationsList.Add(interlocations);
                    }
                    foreach (string locname in internalLocationsList)
                    {
                        ddlLocation.Items.Add(new ListItem(locname));
                        conn.Close();
                    }
                    conn.Close();
                }
                conn.Close();
            }
        }  
