    try
    {
        using (var conn = new SqlConnection(@"...;MultipleActiveResultSets=True"))
        using (var cmdOuter = new SqlCommand(@"select distinct NodeLevel from Org", conn))
        {
            conn.Open();
            using (var outerReader = cmd.ExecuteReader())
            {
                while (outerReader.Read())
                {
                    var nodeLevel = reader.GetInt32(0);
                    Console.WriteLine("Node {0}", nodeLevel);
                    using (var cmdInner = new SqlCommand(@"select Name from Org WHERE NodeLevel = @NodeLevel", conn))
                    {
                        cmdInner.Parameters.AddWithValue("@NodeLevel", nodeLevel);
                        using (var innerReader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Item {0}", innerReader.GetString(0));
                        }
                    }
                }
            }
        }
    }
    catch (SqlException ex)
    {
        MessageBox.Show(ex.Message);
    }
