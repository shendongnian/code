    public bool IsInPattern(int inputToTest, string pattern)
    {
        if (pattern.Contains(","))
            return pattern.Split(',').Contains(inputToTest.ToString());
        else
        {
            var temp = pattern.Split(';');
            if (temp.Contains(inputToTest.ToString()))
                return true;
            else
            {
                temp = temp.RemoveAll(x => !x.Contains("-"));
                foreach (var x in temp)
                {
                    string[] a = x.Split("-").Select(x => x.Trim('[',']')).ToArray();
                    if (IsInRange(inputToTest, int.Parse(a[0]), int.Parse(a[1])))
                        return true;
                }
            }
        }
        return false;
    }
    
    public bool IsInRange(int inputToTest, int start, int end)
    {
        return inputToTest >= start && inputToTest <=end;
    }
