    public static void HtmlDecode(string value, TextWriter output)
    {
        if (value == null)
        {
            return;
        }
        if (output == null)
        {
            throw new ArgumentNullException("output");
        }
        if (value.IndexOf('&') < 0)
        {
            output.Write(value);        // good as is
            return;
        }
        int l = value.Length;
        for (int i = 0; i < l; i++)
        {
            char ch = value[i];
            if (ch == '&')
            {
                // We found a '&'. Now look for the next ';' or '&'. The idea is that
                // if we find another '&' before finding a ';', then this is not an entity,
                // and the next '&' might start a real entity (VSWhidbey 275184)
                int index = value.IndexOfAny(_htmlEntityEndingChars, i + 1);
                if (index > 0 && value[index] == ';')
                {
                    string entity = value.Substring(i + 1, index - i - 1);
                    if (entity.Length > 1 && entity[0] == '#')
                    {
                        // The # syntax can be in decimal or hex, e.g.
                        //      å  --> decimal
                        //      å  --> same char in hex
                        // See http://www.w3.org/TR/REC-html40/charset.html#entities
                        ushort parsed;
                        if (entity[1] == 'x' || entity[1] == 'X')
                        {
                            UInt16.TryParse(entity.Substring(2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out parsed);
                        }
                        else
                        {
                            UInt16.TryParse(entity.Substring(1), NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out parsed);
                        }
                        if (parsed != 0)
                        {
                            ch = (char)parsed;
                            i = index; // already looked at everything until semicolon
                        }
                    }
                    else
                    {
                        i = index; // already looked at everything until semicolon
                        char entityChar = HtmlEntities.Lookup(entity);
                        if (entityChar != (char)0)
                        {
                            ch = entityChar;
                        }
                        else
                        {
                            output.Write('&');
                            output.Write(entity);
                            output.Write(';');
                            continue;
                        }
                    }
                }
            }
            output.Write(ch);
        }
    }
