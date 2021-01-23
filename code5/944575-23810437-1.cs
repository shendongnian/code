    protected void bn_add_Click(object sender, EventArgs e)
    {
        // good idea to check if you have selected items
        if (listbox_selected.SelectedItems.Count == 0) return;
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
                // if your table has more than one column you need to use: insert into table (col1) values ('data')            
                command.ExecuteNonQuery();
            }
       }
    }
