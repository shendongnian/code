    list.ForEach(item => 
                {
                    if (item.Parent == null)
                    {
                        orderedList.Add(item);
                        orderedList.AddRange(list.Where(child => child.Parent == item.Id));
                    }
                });
