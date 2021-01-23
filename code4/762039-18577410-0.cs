    using BinaryAnalysis.UnidecodeSharp;
    using System.Text.RegularExpressions;
    public static void MakeSubdomain(string rawSubdomain, string baseDomain)
    {
        if (baseDomain.Length + 2 > 253) {
            throw new InvalidArgumentException("Base domain is already too long for a subdomain");
        }
        if (baseDomain.Length == 0) {
            throw new InvalidArgumentException("Invalid base domain");
        }
        var sub = rawSubdomain.Unidecode();
        sub = Regex.Replace(sub, @"[^a-zA-Z0-9-]+", "");
        sub = Regex.Replace(sub, @"(^-+)|(-+$)", "");
        sub = sub.ToLowerInvariant();
        if (sub.Length > 63) {
            sub = sub.Substring(0, 63);
        }
        if (sub.Length + baseDomain.Length + 1 > 253) {
            sub = sub.Substring(0, 252 - baseDomain.Length);
        }
        return sub + "." + baseDomain;
    }
