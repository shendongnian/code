                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "DetailedUtility")
                    {
                        Utility_id.Add(reader.GetAttribute(0));
                        population.Add(0);
                        i++;
                    }
                    if (reader.Name == "City")
                    {
                        population[i-1] += Convert.ToInt32(reader.GetAttribute(1));
                    }
                }
            }
            for (i = 0; i < Utility_id.Count; i++)
            {
                Console.WriteLine("Utility ID = " + Utility_id[i] + "\t Population = " + population[i]);
            }
                Console.ReadLine();
