    public IEnumerable<YourObject[]> GetRows()
    {
        using (var connection = new SqlConnection())
        {
            var command = connection.CreateCommand();
            command.CommandText = "select * from [yourtable] order by newid()";
            using (var reader = command.ExecuteReader())
            {
                var lst = new List<YourObject>(20);
                while (true)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (!reader.Read())
                        {
                            break;
                        }
                        var obj = new YourObject();
                        // Read your row
                        lst.Add(obj);
                    }
                    if (lst.Count == 0)
                    {
                         break;
                    }
                    yield return lst.ToArray();
                    if (lst.Count != 20)
                    {
                        break;
                    }
                    lst.Clear();
                }
            }
        }
    }
