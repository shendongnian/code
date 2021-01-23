    @{
    string degerAd = Convert.ToString(ViewData["degerlerAd"]);
    int count2 = degerAd.Count(f => f == '-');
    string[] ar2 = { "-" };
    for (int i = 0; i < count2; i++)
    {
        string[] split2 = degerAd.Split(ar2, StringSplitOptions.RemoveEmptyEntries);
        int dupCount = 0;
        foreach (string s in split2)
        {
            if (s == split2[0])
            {
                dupCount += 1; 
            }
          
        }
        
        if(dupCount > 1)
        {
            dupCount = dupCount - 1;
            i = i + dupCount;
        }
        <li>@split2[0]</li>
        degerAd = degerAd.Replace(split2[0], "");
    }
    }
