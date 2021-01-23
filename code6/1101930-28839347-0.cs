    public ItemCollection GetValues()
    {
        var printers = new ItemCollection();
        for (int i = 0; i < 7; i++)
        {
            string entry = "Option - " + i;
            printers.Add(entry, entry);
        }
        return printers;
    }
