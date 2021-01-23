    private void ResetToZero()
    {
        wholeDigits = new List<int> { 0 };
        decimalDigits = new List<int> { 0 };
        IsWhole = true;
        IsNegative = false;
    }
    private void NormalizeLists()
    {
        RemoveLeadingZeroes(wholeDigits);
        RemoveTrailingZeroes(decimalDigits);
        IsWhole = (decimalDigits.Count == 0 
            || (decimalDigits.Count == 1 && decimalDigits[0] == 0));
    }
    private void AddLeadingZeroes(List<int> list, int numberOfZeroes)
    {
        if (list == null) return;
        for (int i = 0; i < numberOfZeroes; i++)
        {
            list.Insert(0, 0);
        }
    }
    private void AddTrailingZeroes(List<int> list, int numberOfZeroes)
    {
        if (list == null) return;
        for (int i = 0; i < numberOfZeroes; i++)
        {
            list.Add(0);
        }
    }
    private void RemoveLeadingZeroes(List<int> list, bool leaveOneIfEmpty = true)
    {
        if (list == null) return;
        var temp = list;
        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i] == 0)
            {
                list.RemoveAt(i);
            }
            else
            {
                break;
            }
        }
        if (leaveOneIfEmpty && !list.Any()) list.Add(0);
    }
    private void RemoveTrailingZeroes(List<int> list, bool leaveOneIfEmpty = true)
    {
        if (list == null) return;
        var temp = list;
        for (int i = temp.Count -1; i >= 0; i--)
        {
            if (temp[i] == 0)
            {
                list.RemoveAt(i);
            }
            else
            {
                break;
            }
        }
        if (leaveOneIfEmpty && !list.Any()) list.Add(0);
    }
