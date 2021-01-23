     public Dictionary<int, int> Relatedness2(IList<Item> compare, Item compare_to)
            {
                int compare_to_length = compare_to.generator_list.Count;
                var intersectionData = new Dictionary<int, int>();
                foreach (Item block in compare)
                {
                    int block_length = block.generator_list.Count;
                    int both = 0;
                    if (compare_to_length < block_length)
                    {
                        foreach (string word in compare_to.generator_list)
                        {
                            if (block.generator_list.Contains(word))
                            {
                                both = both + 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (string word in block.generator_list)
                        {
                            if (compare_to.generator_list.Contains(word))
                            {
                                both = both + 1;
                            }
                        }
                    }
                    intersectionData[block.index] = both;
                }
                return intersectionData;
            }
