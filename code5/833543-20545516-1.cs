    string numbers = "1,2,3\n4,5,6\n7,8,9";
    int temp;
    IEnumerable<int> parsedNumbers =
                    numbers.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(r => r.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    .SelectMany(r => r)
                    .Select(r => { return int.TryParse(r, out temp) ? temp : int.MinValue; });
