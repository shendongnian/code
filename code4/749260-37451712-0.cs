					Dictionary<string, int> Dictionary1 = new Dictionary<string, int>();
					d1.Add("data1",10);
					d1.Add("data2",11);
					d1.Add("data3",12);
					Dictionary<string, int> Dictionary2 = new Dictionary<string, int>();
					d2.Add("data3", 12);
					d2.Add("data1",10);
					d2.Add("data2",11);
					bool equal = false;
                    if (Dictionary1.Count == Dictionary2.Count) // Require equal count.
                    {
                        equal = true;
                        foreach (var pair in Dictionary1)
                        {
                            int tempValue;
                            if (Dictionary2.TryGetValue(pair.Key, out tempValue))
                            {
                                // Require value be equal.
                                if (tempValue != pair.Value)
                                {
                                    equal = false;
                                    break;
                                }
                            }
                            else
                            {
                                // Require key be present.
                                equal = false;
                                break;
                            }
                        }
                    }
                    if (equal == true)
                    {
                        Console.WriteLine("Content Matched");
                    }
                    else
                    {
                        Console.WriteLine("Content Doesn't Matched");
                    }
