    if (sortDirection == SortDirection.ASC)
                        {
                            newlist = newlist.OrderBy(item => ReflectionHelper.GetPropertyValue(item, jtSorting))).ToList();
                        }
                        else
                        {
                            newlist = newlist.OrderByDescending(item => ReflectionHelper.GetPropertyValue(item, jtSorting))).ToList();
                        } 
