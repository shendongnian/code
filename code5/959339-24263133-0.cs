    string foo = @"
    TKT-2207434010779-780 RCI- 1A LOC-68XMG5
    OD-HOUHOU SI- FCMI-F POI-NYC DOI-02JUN14 IOI-10729143
    1.WAHBA/REDA ADT ST
    1 OIAH LH7620UA L 07JUN2050 OK LHHNC5N/CN05 F 07JUN07JUN 1PC
    2 XLHR LH 911 L 08JUN1645 OK LHHNC5N/CN05 F 08JUN08JUN 1PC
    3 XFRA LH 584 L 08JUN2130 OK LHHNC5N/CN05 F 08JUN08JUN 1PC
    4 OCAI LH 585 L 06JUL0340 OK LHHNC5N/CN05 O 06JUL06JUL 1PC
    5 XFRA LH 440 L 06JUL1000 OK LHHNC5N/CN05 O 06JUL06JUL 1PC
    IAH
    FARE F USD 522.00
    TOTALTAX USD 656.80
    TOTAL USD 1178.8
    ";
    StringReader reader = new StringReader(foo);
    string line;
    List<string> list = new List<string>();
    while (null != (line = reader.ReadLine()))
    {
       Regex r = new Regex(@"^\s\d.+?\W{1}([A-Z]) \W{2}", RegexOptions.Multiline);
       if(r.IsMatch(line)){
       MatchCollection m = r.Matches(line);
       string value = m[0].Groups[1].ToString();
       list.Add(value); 
       }
      }
     
