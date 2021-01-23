    private static string Unescape(string value) {
        if (value == null)
            return null;
        var length = value.Length;
        var result = new StringBuilder(length);
        for (var i = 0; i < length; i++) {
            var c = value[i];
            if (c == '\\' && i++ < length) {
                c = value[i];
                switch (c)
                {
                    case 'n':
                        result.Append('\n');
                        break;
                    case 'r':
                        result.Append('\r');
                        break;
                    case 't':
                        result.Append('\t');
                        break;
                    case '\\':
                        result.Append('\\');
                        break;
                    default:
                        result.Append(c);
                        break;
                }
            }
            else {
                result.Append(c);
            }
        }
        return result.ToString();
    }
