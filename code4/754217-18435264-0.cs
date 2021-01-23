    static public List<Name> GetNamedRangesInOrder(Workbook activeWorkbook)
    {
        List<Name> namedRanges = GetNamedRanges(activeWorkbook);
    
        List<string> lstStringNameRanges = new List<string>();
        foreach (var item in namedRanges)
        {
            lstStringNameRanges.Add(RemoveDigits(item.RefersTo.ToString()));
        }
    
        IEnumerable<string> results = SortByLengthAndName(lstStringNameRanges);
        List<Name> sortedNamedRanges = new List<Name>();
        foreach (var item in results)
        {
            int index = -1;
            for (int i=0; i < namedRanges.Count; i++)
            {
                if (RemoveDigits(namedRanges[i].RefersTo.ToString()) == item.ToString())
                {
                    index = i;
                    break;
                }
            }
            sortedNamedRanges.Add(namedRanges[index]);
        }
        return sortedNamedRanges;
               
    }
    
    static public IEnumerable<string> SortByLengthAndName(IEnumerable<string> e)
    {
        IEnumerable<string> query = e.OrderBy(x => x.Length).ThenBy(x => x).ToList();
        return query;
    }
    
    static public string RemoveDigits(string e)
    {
        string str = new string((from c in e
                where char.IsLetter(c) || char.IsSymbol(c)
                select c).ToArray());
    
        return str;
    }
