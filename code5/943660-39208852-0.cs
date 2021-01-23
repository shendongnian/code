    public static string Rot47(string input)
    {
        return !string.IsNullOrEmpty(input) ? new string(input.Select(x =>
            (x >= 33 && x <= 126) ? (char)((x + 14) % 94 + 33) : x).ToArray()) : input;
    }
    public static string Rot13(string input)
    {
        return !string.IsNullOrEmpty(input) ? new string(input.Select(x =>
            (x >= 'a' && x <= 'z') ? (char)((x - 'a' + 13) % 26 + 'a') :
            (x >= 'A' && x <= 'Z') ? (char)((x - 'A' + 13) % 26 + 'A') : x).ToArray()) : input;
    }
    public static string Rot39(string input)
    {
        // This string contains 78 different characters in random order.
        var mix = "QDXkW<_(V?cqK.lJ>-*y&zv%9prf8biYCFeMxBm6ZnG3H4OuS1UaI5TwtoA#Rs!,7d2@L^gNhj)EP$0";
        var result = (input ?? "").ToCharArray();
        for (int i = 0; i < result.Length; ++i)
        {
            int j = mix.IndexOf(result[i]);
            result[i] = (j < 0) ? result[i] : mix[(j + 39) % 78];
        }
        return new string(result);
    }
