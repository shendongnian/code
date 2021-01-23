    var item = new IPMAC();
    foreach (Match match in matches)
    {
          Console.WriteLine("Hardware Address : {0}", match.Groups[1].Value);
          item.mac = match.Groups[1].Value;
    }
    foreach (Match match in matchesIP)
    {
          Console.WriteLine("IP Address : {0}", match.Groups[1].Value);
          item.ip = match.Groups[1].Value;
    }
    ipmac.Add(item);
