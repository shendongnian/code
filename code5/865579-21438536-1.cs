    string Hyphenate(string str, int pos) {
        return String.Join("-",
            Enumerable.Range(0, (str.Length - 1) / pos + 1)
                .Select(i => str.Substring(i * pos, Math.Min(str.Length - i * pos, pos))));
    }
    Console.WriteLine(Hyphenate("abcdxy123z", 2)); // ab-cd-xy-12-3z
    Console.WriteLine(Hyphenate("abcdxy123z", 3)); // abc-dxy-123-z
    Console.WriteLine(Hyphenate("abcdxy123z", 4)); // abcd-xy12-3z
