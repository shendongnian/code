    var ips = new List<string>();
    var domains = new List<string>();
    foreach (var elements in txt.Text
        .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Skip(1)
        .Select(line => line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)))
    {
        ips.Add(elements[0]);
        domains.Add(elements[1]);
    }
    ipsArray = ips.ToArray();
    domainsArray = domains.ToArray();
