    using System.Linq;
    public static bool ContainsAlpha(string s)
    {
        return s != null && s.Any(Char.IsLetter);
    }
