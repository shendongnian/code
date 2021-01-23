        DataTable p_table = new DataTable();
        con = new MySqlConnection("Data Source=christina\\sqlexpress;Initial 
                             Catalog=cafe_inventory;User ID=sa;Password=tina;");
        con.Open();
        MySqlCommand command1 = new MySqlCommand("Select pname from inventory where
                                                         qt < 5", con);
        p_table.load(command1.ExecuteReader());
