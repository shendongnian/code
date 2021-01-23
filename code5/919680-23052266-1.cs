    if (sortDirection == SortDirection.ASC)
                        {
                            newlist = newlist.OrderBy(item => GetPropertyValue(item, jtSorting))).ToList();
                        }
                        else
                        {
                            newlist = newlist.OrderByDescending(item => GetPropertyValue(item, jtSorting))).ToList();
                        } 
