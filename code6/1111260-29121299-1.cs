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
                    // Micro-optimization: we don't keep two copies
                    // of the lst after the yield
                    bool last = lst.Count != 20;
                    var array = lst.ToArray();
                    lst.Clear();
                    yield return array;
                    if (last)
                    {
                        break;
                    }
                }
            }
        }
    }
