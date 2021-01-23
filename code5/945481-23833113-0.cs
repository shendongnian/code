    IEnumerable<string> compact = myList.Select(
        (item) => new string[] { item.String1, item.String2, item.String3, item.String4 }
            .Aggregate((last, actual) => 
                (last.GetHashCode() + actual.GetHashCode()).ToString()
            ));
    
    bool areAllSame = compact.Skip(1)
        .FirstOrDefault((item) => item != compact.First()) == null;
