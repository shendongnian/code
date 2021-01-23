                string done = "";
                for (int i = 0; i < 624; i++)
                {
                    if (!done.Contains(census[i][0]))
                    {
                        Console.WriteLine(census[i][0]);
                        Select(census[i][0]);
                    }
                    done=done+census[i][0];
                }
