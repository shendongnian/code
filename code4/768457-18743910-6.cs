    private void WriteGuidFile(string filename, Dictionary<string, Guid>guids)
    {
        using (var fs = File.Create(filename))
        {
            using (var writer = new BinaryWriter(fs, Encoding.UTF8))
            {
                List<int> stringIndex = new List<int>(guids.Count);
                StringBuilder bigString = new StringBuilder();
                // write count
                writer.Write(guids.Count);
                // Write the GUIDs and build the string index
                foreach (var pair in guids)
                {
                    writer.Write(pair.Value.ToByteArray(), 0, 16);
                    stringIndex.Add(bigString.Length);
                    bigString.Append(pair.Key);
                }
                // Add one more entry to the string index.
                // makes deserializing easier
                stringIndex.Add(bigString.Length);
                // Write the string that contains all of the strings, combined
                writer.Write(bigString.ToString());
                // write the index
                foreach (var ix in stringIndex)
                {
                    writer.Write(ix);
                }
            }
        }
    }
