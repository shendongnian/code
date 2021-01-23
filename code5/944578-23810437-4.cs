    protected void bn_add_Click(object sender, EventArgs e)
    {
        // good idea to check if you have selected items
        if (listbox_selected.SelectedIndex == -1) return;
        // using will take care of closing and disposing
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FYP"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.Text;
                // if your listbox is multiselect, all you need is to check 'selected items'
                foreach (ListItem item in listbox_selected.Items)
                {
                    if (item.Selected == true)
                    {
                        // here you didn't have 'values' in your sql query
                        command.CommandText = "INSERT INTO Competency_TechnicalSkill values('" + item.ToString() + "')"; 
                        // if your table has more than one column you need to use: insert into table (col1) values ('data')            
                        command.ExecuteNonQuery();
                    }
                }
            }
       }
    }
