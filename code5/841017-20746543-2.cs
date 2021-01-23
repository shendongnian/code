        SortedList sortedList = new SortedList(StringComparer.Ordinal);
        try
        {
            sortedList.Add("bœuf", "Value1");
            sortedList.Add("boeuf", "Value1");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
