    char[] charArray = x.ToString().ToCharArray();
    bool zeroControl = false;
    List<int> counts = new List<int>();
    int currentCount = 0;
    for (int i = 0; i < charArray.Length; i++)
    {
        if (charArray[i] == '0' && !zeroControl)
        {
             zeroControl = true;
             currentCount++;
        }
        else if (charArray[i] == '0')
        {
             currentCount++;
        }
        else
        {
             zeroControl = false;
             counts.Add(currentCount);
             currentCount = 0;
        }
    }
    counts.Add(currentCount);
    var result = counts.Max();
           
