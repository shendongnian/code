    public static string con_str = "Server=localhost;Database=databaserfid;Username=root;Password=12345";
            static MySqlConnection con = new MySqlConnection(con_str);
            public static MySqlConnection connection()
            {
                try
                {
                con.Open();
            }            
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.ToString());
            }
            return con;
        }
