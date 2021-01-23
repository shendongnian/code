    List<string> items = new List<string>(); // declare globally
    
    private void add(string item)
    {
       items.Add(item);
    }
    
    private void remove(string item)
    {
       items.Remove(item);
    }
    
    private string convertArrayToString(string delimiter, List<string> elements)
    {
       delimiter = (delimiter == null) ? "" : delimiter;
       return string.Join(delimiter, elements.ToArray());
    }
