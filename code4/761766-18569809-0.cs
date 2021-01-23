        List<string> listA = new List<string> { "A", "A", "B", "C", "D", "E" };
        List<string> listRef = new List<string> { "A", "D" };
        foreach (var item in listRef)
        {
            if (listA.Where(x => x.Equals(item)).Count() > 1)
            { 
            //item is present more than once
            }
        }
