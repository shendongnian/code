    public static IEnumerable<object[]> ParseStream(TextReader tr, Type[] types, IFormatProvider culture = null)
    {
        var parts = new List<string>();
        var sb = new StringBuilder();
        State state = State.WaitingForOpenBracket;
        long col = -1;
        long row = 0;
        int read;
        while ((read = tr.Read()) != -1)
        {
            col++;
            char ch = (char)read;
            if (ch == '\n')
            {
                col = 0;
                row++;
            }
            else
            {
                col++;
            }
            switch (state)
            {
                case State.WaitingForOpenBracket:
                    if (ch != '(')
                    {
                        throw new Exception(string.Format("Malformed begin-of-the-row at R: {0}, C: {1}, char: {2}", row, col, ch));
                    }
                    state = State.WaitingForData;
                    break;
                case State.WaitingForData:
                case State.WaitingForColumnSeparator:
                    if (ch == ',' || ch == ')')
                    {
                        parts.Add(sb.ToString());
                        sb.Clear();
                        if (parts.Count > types.Length)
                        {
                            throw new Exception(string.Format("Too many parts starting at R: {0}, C: {1}", row, col));
                        }
                        if (ch == ')')
                        {
                            var parts2 = parts.Select((p, ix) => Convert.ChangeType(p, types[ix], culture ?? CultureInfo.InvariantCulture)).ToArray();
                            parts.Clear();                                
                            yield return parts2;
                            state = State.WaitingForRowSeparator;
                        }
                    }
                    else
                    {
                        if (state == State.WaitingForColumnSeparator)
                        {
                            throw new Exception(string.Format("Malformed column separator at R: {0}, C: {1}, char: {2}", row, col, ch));
                        }
                        if (ch == '"')
                        {
                            if (sb.Length != 0)
                            {
                                throw new Exception(string.Format("Malformed string at R: {0}, C: {1}, char: {2}", row, col, ch));
                            }
                            state = State.WaitingForEndQuotes;
                        }
                        else
                        {
                            sb.Append(ch);
                        }
                    }
                    break;
                case State.WaitingForEndQuotes:
                    if (ch == '"')
                    {
                        state = State.WaitingForColumnSeparator;
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                    break;
                case State.WaitingForRowSeparator:
                    if (ch != ',')
                    {
                        throw new Exception(string.Format("Malformed row separator at R: {0}, C: {1}, char: {2}", row, col, ch));
                    }
                    state = State.WaitingForOpenBracket;
                    break;
            }
        }
        if (state != State.WaitingForRowSeparator)
        {
            throw new Exception(string.Format("Malformed end-of-file at R: {0}, C: {1}", row, col));
        }
    }
