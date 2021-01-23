    string numbers = "1,2,3\n4,5,6\n7,8,9";
    IEnumerable<int> parsedNumbers =
        numbers.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
               .SelectMany(r => r.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
               .Select(int.Parse);
