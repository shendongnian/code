    public static List<List<int>> ThreeSum(int[] num)
    {
        List<List<int>> returnList = new List<List<int>>();
        foreach (int i in num)
        {
            foreach (int j in num)
            {
                foreach (int k in num)
                {
                    if (i + j + k == 0 && i <= j && j <= k && !(i == 0 || j == 0 || k == 0))
                    {
                        List<int> listInt = new List<int> {i, j, k};
                        if (!returnList.Contains(listInt))
                        {
                            returnList.Add(listInt);
                        }
                    }
                }
            }
        }
        return returnList;
    }
