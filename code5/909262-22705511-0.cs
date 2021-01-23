    public static List<T> OrderdMergeList<T>(this List<T> master, List<T> secondary)
        {
            var output = master.ToList();
            var itemsToInsert = new List<T>();
            int? lastMatchIndex = null;
            foreach (var item in secondary)
            {
                if (output.Contains(item))
                {
                    if (!lastMatchIndex.HasValue)
                    {
                        //already in the list so insert any items we have before this and not already in the output
                        var index = output.IndexOf(item);
                        output.InsertRange(index, itemsToInsert);
                        itemsToInsert.Clear();
                        lastMatchIndex = output.IndexOf(item);//updates it to new position
                    }
                    else
                    {
                        //already in the list but also already found a match so need to be careful for out of order info
                        var index = output.IndexOf(item);
                        if (index > lastMatchIndex.Value)
                        {
                            output.InsertRange(index, itemsToInsert);
                            itemsToInsert.Clear();
                            lastMatchIndex = output.IndexOf(item); //updates it to new position
                        }
                        else
                        {
                            output.InsertRange(lastMatchIndex.Value+1, itemsToInsert);
                            if (itemsToInsert.Count > 0)
                            {
                                lastMatchIndex = output.IndexOf(itemsToInsert.Last()); //updates it to new position
                            }
                            else
                            {
                                lastMatchIndex += 1;
                            }
                            itemsToInsert.Clear();
                            
                        }
                    }
                }
                else
                {
                    //not in the output so add it to the list to insert when we find a match
                    itemsToInsert.Add(item);        
                }
            }
            //insert any left over items on the end
            output.AddRange(itemsToInsert);
            return output;
            //return master.Union(secondary).ToList();
        }
