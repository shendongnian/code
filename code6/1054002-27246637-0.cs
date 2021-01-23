        foreach (RepeaterItem ri in repeater.Items)
        {
            CheckBox item_check = (CheckBox)ri.FindControl("item_check");
            Label txt_id = (Label)ri.FindControl("txt_id");
            if (item_check.Checked)
            {
                con = new SqlConnection(strcon);
                cmd = new SqlCommand("ram", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@eid", txt_id.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                   
                    con.Close();
                }
            }
        }
        repeat();
