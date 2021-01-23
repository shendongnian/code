    var escape = new Regex(@"\\(x[0-9A-Fa-f]{4}|y[0-9A-Fa-f]{5}|z[0-9A-Fa-f]{8}|.)");
    var chars = new Dictionary<char, string> {
        { 'f', "\f" }, { 'n', "\n" }, { 'r', "\r" }, { 't', "\t" }, { 'v', "\v" },
        { 's', " " }, { 'e', "\x1B"}
    };
    var decoded_string = escape.Replace(encoded_string, match =>
        match.Length>2 ?
            Char.ConvertFromUtf32(
                int.Parse(
                    match.Value.Substring(2),
                    System.Globalization.NumberStyles.HexNumber
                )
            ) :
        chars.ContainsKey(match.Value[1]) ?
            chars[match.Value[1]] :
        match.Value.Substring(1)
    );
