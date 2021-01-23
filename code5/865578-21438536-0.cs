    string Hyphenate(string str, int pos) {
        return String.Join("-",
            str.Select((c, i) => new { c, i })
               .GroupBy(x => x.i / pos)
               .Select(g => String.Join("", g.Select(x => x.c))));
    }
    Console.WriteLine(Hyphenate("abcdxy123z", 2)); // ab-cd-xy-12-3z
    Console.WriteLine(Hyphenate("abcdxy123z", 3)); // abc-dxy-123-z
    Console.WriteLine(Hyphenate("abcdxy123z", 4)); // abcd-xy12-3z
