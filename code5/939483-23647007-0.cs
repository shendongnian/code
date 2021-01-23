    static IEnumerable<string> EnumerateKeys(string[][] parts)
    {
        return EnumerateKeys(parts, string.Empty, 0);
    }
    
    static IEnumerable<string> EnumerateKeys(string[][] parts, string parent, int index)
    {
        if (index == parts.Length - 1)
            for (int col = 0; col < parts[index].Length; col++)
                yield return parent + parts[index][col];
        else
            for (int col = 0; col < parts[index].Length; col++)
                foreach (string key in EnumerateKeys(parts, parent + parts[index][col], index + 1))
                    yield return key;
    }
