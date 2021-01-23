                StringBuilder sqlQuery;
                SqlConnection con = new SqlConnection(@"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword; ");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string join = "";
                // textboxes
                if (TextBox_percentage.Text.Trim() != "")
                {
                    sqlQuery.Append(join+" [percentage_column]>=@percentage");
                    cmd.Parameters.AddWithValue("@percentage", TextBox_percentage.Text);
                    join = " and ";
                }
                if (TextBox_cgpa.Text.Trim() != "")
                {
                    sqlQuery.Append(join + " [cgpa_column]>=@cgpascore");
                    cmd.Parameters.AddWithValue("@cgpascore", TextBox_cgpa.Text);
                    join = " and ";
                }
                if (TextBox_experience.Text.Trim() != "")
                {
                    sqlQuery.Append(join + " [experience_column]=@experience");
                    cmd.Parameters.AddWithValue("@experience", TextBox_experience.Text);
                    join = " and ";
                }
                // dropdowns, 'Default value'? Text/Value?
                if (dropdown_Industry.SelectedItem.Text != "Default Value")
                {
                    sqlQuery.Append(join + " [Industry_column]=@Industry");
                    cmd.Parameters.AddWithValue("@Industry", dropdown_Industry.SelectedItem.Text);
                    join = " and ";
                }
                if (dropdown_Specialization.SelectedItem.Text != "Default Value")
                {
                    sqlQuery.Append(join + " [Specialization _column]=@Specialization ");
                    cmd.Parameters.AddWithValue("@Specialization ", dropdown_Specialization.SelectedItem.Text);
                    join = " and ";
                }
                if (dropdown_Highest_degree.SelectedItem.Text != "Default Value")
                {
                    sqlQuery.Append(join + " [Highest_degree_column]=@Highest_degree");
                    cmd.Parameters.AddWithValue("@Highest_degree", dropdown_Highest_degree.SelectedItem.Text);
                    join = " and ";
                }
                if (dropdown_College.SelectedItem.Text != "Default Value")
                {
                    sqlQuery.Append(join + " [College_column]=@College");
                    cmd.Parameters.AddWithValue("@College", dropdown_College.SelectedItem.Text);
                    join = " and ";
                }
                if (dropdown_Location.SelectedItem.Text != "Default Value")
                {
                    sqlQuery.Append(join + " [Location_column]=@Location");
                    cmd.Parameters.AddWithValue("@Location", dropdown_Location.SelectedItem.Text);
                    join = " and ";
                }
                cmd.CommandText = "Select * from table where " + sqlQuery.ToString();
                con.Open(); // try-catch-finally
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                gridView.DataSource = dt;
                gridView.DataBind();
