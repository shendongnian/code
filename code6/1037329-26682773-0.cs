    public static List<int> MyTakeWhile(this List<int> input, Func<int, int, bool> predicate)
    {
        var result = new List<int>();
        for (var i = 0; i < input.Count; i++)
        {
            if (predicate(input[i], i))
                result.Add(input[i]);
            else
                break;
        };
        return result;
    }
