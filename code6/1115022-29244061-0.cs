    Dictionary<string, string> complementary = new Dictionary<string,string>()
    {
        { "A", "T" },
        { "T", "A" },
        { "C", "G" },
        { "G", "C" }
    };
    string input = "ATCG";
    string result = Regex.Replace(input, "[ATCG]", match => complementary[match.Value]);
