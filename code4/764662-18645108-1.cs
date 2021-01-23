    var ws = new Regex("\\S");
    for (char c = '\0'; c != 0xffff; c++) {
        if (char.IsWhiteSpace(c)) {
            var m = ws.Match("" + c);
            if (m.Value.Length != 0) {
                Console.Error.WriteLine("Found a mismatch: {0}", (int)c);
            }
        }
    }
