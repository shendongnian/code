    @{
        string degerAd = Convert.ToString(ViewData["degerlerAd"]);
        int count2 = degerAd.Count(f => f == '-');
        string[] ar2 = { "-" };
        string[] split2 = degerAd.Split(ar2, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < count2; i++)
        {
            <li>@split2[i]</li>
        }
    }
