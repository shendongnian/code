    try
        {
            sqlcon.Open();
            cmd = new SqlCommand("select d.id from _dept d left join user u on u.id = d.id where u.email = '" + Email + "' order by d.id;", sqlcon);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListItem li = ChkStatus.Items.FindByValue(reader["id"].ToString());
                if (li != null)
                {
                    li.Selected = true;
                }
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Found Error in Selecting your depart!");
            Response.Redirect("user.aspx", false);
        }
        finally { sqlcon.Close(); }
