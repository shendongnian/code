    static readonly Dictionary<byte, string> _byteToAttributeText =
        new Dictionary<byte, string>()
        {
            { 0, "First Attribute Text" },
            { 1, "Second Attribute Text" },
            { 2, "Third Attribute Text" },
        };
    static string GetAttributeText(byte value)
    {
        string text;
        if (!_byteToAttributeText.TryGetValue(value, out text))
        {
            return "<unknown attribute>";
        }
        return text;
    }
