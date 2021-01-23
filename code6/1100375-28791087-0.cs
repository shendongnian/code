    public static class StreamEx
    {
        public static string[] ReadAllLines(this TextReader tr, string separator)
        {
            return tr.ReadLines(separator).ToArray();
        }
        // StreamReader is based on TextReader
        public static IEnumerable<string> ReadLines(this TextReader tr, string separator)
        {
            // Handling of empty file: old remains null
            string old = null;
            // Read buffer
            var buffer = new char[128];
            while (true)
            {
                // If we already read something
                if (old != null)
                {
                    // Look for the separator
                    int ix = old.IndexOf(separator);
                    // If found
                    if (ix != -1)
                    {
                        // Return the piece of line before the separator
                        yield return old.Remove(ix);
                        // Then remove the piece of line before the separator plus the separator
                        old = old.Substring(ix + separator.Length);
                        // And continue 
                        continue;
                    }
                }
                // old doesn't contain any separator, let's read some more chars
                int read = tr.ReadBlock(buffer, 0, buffer.Length);
                // If there is no more chars to read, break the cycle
                if (read == 0)
                {
                    break;
                }
                // Add the just read chars to the old chars
                // note that null + "somestring" == "somestring"
                old += new string(buffer, 0, read);
                // A new "round" of the while cycle will search for the separator
            }
            // Now we have to handle chars after the last separator
            // If we read something
            if (old != null)
            {
                // Return all the remaining characters
                yield return old;
            }
        }
    }
