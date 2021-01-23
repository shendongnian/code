                delegate bool CheckList(int lowIndex, List<int> list);
                CheckList HasDuplicate = (List<dynamic> list, int item) =>
                {
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                        return list.Contains(item) ? true : false;
                    }
                    return false;
                };
