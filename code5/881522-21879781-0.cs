    var lines = new[] { "1 03/MAR/2013 06:41:06 9448485859 00:15 0.40 **",
                        "SNo Date Time Number Duration/Volume Amount" };
    int serialNumber;
    IEnumerable<string> validLines = lines.Where(s => !string.IsNullOrEmpty(s) && 
                                      int.TryParse(s.Split(' ')[0], out serialNumber));
