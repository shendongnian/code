    /// <summary>
    /// Writes the data from a given <see cref="IDataReader"/> <paramref name="reader"/> to the <paramref name="output"/> <see cref="Stream"/>.
    /// There are optional parameters for writing a header, specifying the encoding, the buffer size, and whether or not the stream should be
    /// closed when we're done reading.
    /// </summary>
    /// <param name="reader">Any object which implements <see cref="IDataReader"/>-- most likely a <see cref="System.Data.SqlClient.SqlDataReader"/>.</param>
    /// <param name="output">The stream to output the CSV contents to.</param>
    /// <param name="writeHeader">When true, a header is written using the column names.</param>
    /// <param name="encoding">Optional parameter (defaulting to UTF8 without BOM) denoting how the data should be encoded.</param>
    /// <param name="bufferSize">Optional parameter (defaulting to 1KB) which is used as a buffer for writing the data.</param>
    /// <param name="closeOutput">Optional parameter which, when true, closes the <paramref name="output"/> <see cref="Stream"/> after we're doing writing.</param>
    private static void WriteCsv(IDataReader reader, Stream output, bool writeHeader = true, Encoding encoding = null, int bufferSize = 1024, bool closeOutput = false)
    {
        // If no encoding is provided, use the same one the StreamWriter defaults to.
        if (encoding == null)
            encoding = new UTF8Encoding(false, true);
    
        // Create a new writer to our CSV file.
        using (var writer = new StreamWriter(output, encoding, bufferSize, !closeOutput))
        {
            // This will create an enumerable with every integer between 0 and FieldCount-1.
            // Allows us to do a concise for loop and use String.Join to handle the comma placement.
            var indices = Enumerable.Range(0, reader.FieldCount);
    
            // Keep looping as long as their are rows returned by the reader.
            while (reader.Read())
            {
                // Write a header with the names of each column.
                if (writeHeader)
                {
                    writer.WriteLine(String.Join(",", indices.Select(i => reader.GetName(i) ?? ("column" + i))));
                    writeHeader = false;
                }
    
                // Write the value of each field by its string representation separated by a comma.
                writer.WriteLine(String.Join(",", indices.Select(i => (reader.IsDBNull(i) ? null : reader.GetString(i)) ?? "")));
            }
        }
    }
