    List<string> names = new List<string>();
                names.Add("[1col]"); //you may write your
                names.Add("name");
                string[] arr = names.ToArray();
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select " + String.Join(",", arr) + " from test");
