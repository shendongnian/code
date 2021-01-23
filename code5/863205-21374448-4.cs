    public void ShowRequestedList()
    {
        var lists = GetRequestedList(Enumerable.Range(1, 5), 3);
        foreach (var list in lists)
        {
            var text = String.Join("", list);
            Console.WriteLine(text);
        }
    }
