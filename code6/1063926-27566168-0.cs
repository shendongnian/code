    public void AddElementAtMiddle(List<string> list, string element)
    {
        if (list == null || list.Count == 0) return;
        list.Insert((list.Count / 2), element);
    }
  
