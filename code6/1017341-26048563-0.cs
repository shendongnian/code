    for (int i=0;i<matches.Count;i++)
    {
        matches.CopyTo(odkazy, 0);
        string ano = odkazy[i].ToString();
        neco.Add(ano);
        WebClient klient = new WebClient();
        klient.DownloadFileAsync(new Uri(neco[i]), @"c:\picture{0}.png",i);
        Debug.WriteLine(neco[i]);
    }
