    private JsonToken Parse()
        {
            char ch = NextClean();
            //
            // String
            //
            if (ch == '"' || ch == '\'')
            {
                return Yield(JsonToken.String(NextString(ch)));
            }
            //
            // Object
            //
            if (ch == '{')
            {
                _reader.Back();
                return ParseObject();
            }
            //
            // Array
            //
            if (ch == '[')
            {
                _reader.Back();
                return ParseArray();
            }
            //
            // Handle unquoted text. This could be the values true, false, or
            // null, or it can be a number. An implementation (such as this one)
            // is allowed to also accept non-standard forms.
            //
            // Accumulate characters until we reach the end of the text or a
            // formatting character.
            // 
            StringBuilder sb = new StringBuilder();
            char b = ch;
            while (ch >= ' ' && ",:]}/\\\"[{;=#".IndexOf(ch) < 0) 
            {
                sb.Append(ch);
                ch = _reader.Next();
            }
            _reader.Back();
            string s = sb.ToString().Trim();
            if (s.Length == 0)
                throw SyntaxError("Missing value.");
            
            
            //
            // Boolean
            //
            if (s == JsonBoolean.TrueText || s == JsonBoolean.FalseText)
                return Yield(JsonToken.Boolean(s == JsonBoolean.TrueText));
            
            //
            // Null
            //
            if (s == JsonNull.Text)
                return Yield(JsonToken.Null());
            
            //
            // Number
            //
            // Try converting it. We support the 0- and 0x- conventions. 
            // If a number cannot be produced, then the value will just
            // be a string. Note that the 0-, 0x-, plus, and implied 
            // string conventions are non-standard, but a JSON text parser 
            // is free to accept non-JSON text forms as long as it accepts 
            // all correct JSON text forms.
            //
            if ((b >= '0' && b <= '9') || b == '.' || b == '-' || b == '+')
            {
                if (b == '0' && s.Length > 1 && s.IndexOfAny(_numNonDigitChars) < 0)
                {
                    if (s.Length > 2 && (s[1] == 'x' || s[1] == 'X'))
                    {
                        string parsed = TryParseHex(s);
                        if (!ReferenceEquals(parsed, s))
                            return Yield(JsonToken.Number(parsed));
                    }
                    else
                    {
                        string parsed = TryParseOctal(s);
                        if (!ReferenceEquals(parsed, s))
                            return Yield(JsonToken.Number(parsed));
                    }
                }
                else
                {
                    if (!JsonNumber.IsValid(s))
                        throw SyntaxError(string.Format("The text '{0}' has the incorrect syntax for a number.", s));
                    return Yield(JsonToken.Number(s));
                }
            }
            
            //
            // Treat as String in all other cases, e.g. when unquoted.
            //
            return Yield(JsonToken.String(s));
        }
