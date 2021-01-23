       var duplicates = new List<int>();
            foreach (var i in a)
            {
                var duplicate = 0;
                foreach (var j in i)
                {
                    foreach (var k in b)
                    {
                        if (k == j)
                        {
                            duplicate++;
                        }
                    }
                }
                duplicates.Add(duplicate);
            }
