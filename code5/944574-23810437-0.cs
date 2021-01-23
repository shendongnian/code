    protected void bn_add_Click(object sender, EventArgs e)
    {
        // using will take care of closing and disposing
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FYP"].ConnectionString))
        {
            conn.Open();
            SqlCommand command;
            // if your listbox is multiselect, all you need is to check 'selected items'
            foreach (var item in listbox_selected.SelectedItems)
            {
                // here you didn't have 'values' in your sql query
                command = new SqlCommand("INSERT INTO Competency_TechnicalSkill values('" + item.ToString() + "')", conn);             
                command.ExecuteNonQuery();
            }
       }
    }
