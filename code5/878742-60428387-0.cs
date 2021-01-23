csharp
string LongestCommonSubstring(params string[] strings)
{
    return LongestCommonSubstring(strings[0], new Queue<string>(strings.Skip(1)));
}
string LongestCommonSubstring(string x, Queue<string> strings)
{
    if (!strings.TryDequeue(out var y))
    {
        return x;
    }
    var output = string.Empty;
    for (int i = 0; i < x.Length; i++)
    {
        for (int j = x.Length - i; j > -1; j--)
        {
            string common = x.Substring(i, j);
            if (y.IndexOf(common) > -1 && common.Length > output.Length) output = common;
        }
    }
    return LongestCommonSubstring(output, strings);
}
It's still using recursion though, but it's a nice example of `Queue<T>`.
