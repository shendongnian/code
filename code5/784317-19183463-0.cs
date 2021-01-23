        // Build your final resulting list
        List<String> dane = new List<String>();
        // use StreamReader to read the file
        using (StreamReader sr = new StreamReader(ms))
        {
            // create a string builder that we can use to store each
            // line's contents until it's ready to be added to dane
            StringBuilder builder = new StringBuilder();
            // buffer char
            Char c;
            // read the stream character by character
            while (!sr.EndOfStream)
            {
                c = (Char)sr.Read();
                // if it's `;` it's the end of a row, so add it to
                // dane and reset the line's contents
                if (c == ';')
                {
                    dane.Add(builder.ToString());
                    builder.Clear();
                }
                // avoid reading in superfluous whitespace before we
                // begin reading a line
                else if (builder.Length == 0 && Char.IsWhiteSpace(c))
                {
                    continue;
                }
                // concatenate the current character to our line
                else
                {
                    builder.Append(c);
                }
            }
            // if there's a final row, add it to dane
            if (builder.Length > 0)
            {
                dane.Add(builder.ToString());
            }
        }
        // dane now contains each line's contents.
