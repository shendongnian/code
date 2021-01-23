                var l = new[] { 14, 24, 56, 189, 909, 1000 };
                var groups = new List<List<int>>();
                groups.Add(new List<int>());
                groups[0].Add(l[0]);
                for (int i = 1; i < l.Length; i++)
                {
                    if (l[i] - l[i - 1] > 100)
                    {
                        groups.Add(new List<int>());
                    }
                    groups[groups.Count - 1].Add(l[i]);
                }
