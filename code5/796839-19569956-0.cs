    public bool NewUser(string name, int age)
    {
        // First let's create the using statement:
        // The using statement will make sure your objects will be disposed after
        // usage. Even if you return a value in the block.
        // It's also syntax sugar for a "try - finally" block.
        using (MySqlConnection cn = new MySqlConnection("your connection string here"))
        {
            // Here we have to create a "try - catch" block, this makes sure your app
            // catches a MySqlException if the connection can't be opened, 
            // or if any other error occurs.
            try
            {
                // Here we already start using parameters in the query to prevent
                // SQL injection.
                string query = "INSERT INTO table (name, age) VALUES (@name, @age);";
                
                cn.Open();
                
                // Yet again, we are creating a new object that implements the IDisposable
                // interface. So we create a new using statement.
                
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    // Now we can start using the passed values in our parameters:
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
                    // All went well so we return true
                    return true;
            }
            catch (MySqlException)
            {
                // Here we got an error so we return false
                return false;
            }
        }
    }
