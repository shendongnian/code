     foreach (var entry in dict)
            {
                for (int i = dict.Values.Count - 1; i >= 0; i--)
                {
                    if (entry.Value[i].Equals("Something"))
                    {
                        entry.Value.RemoveAt(i);
                    }
                }
            }
