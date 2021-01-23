    IENumerable<string> split2 = degerAd.Split(ar2, StringSplitOptions.RemoveEmptyEntries).Distinct();
    foreach (string el in split2)
    {
        <li>@el</li>
    }
