    private static IEnumerable<string> Cutup(string given, int chunkSize)
    {
        var skip = 0;
        var iterations = 0;
        while (iterations * chunkSize < given.Length)
        {
            iterations++;                
            yield return new string(given.Skip(skip).Take(chunkSize).ToArray());
            skip += chunkSize;
        }
    }
    private static unsafe IEnumerable<string> Cutup2(string given, int chunkSize)
    {
        var pieces = new List<string>();
        var consumed = 0;
        while (consumed < given.Length)
        {
            fixed (char* g = given)
            {
                var toTake = consumed + chunkSize > given.Length 
                             ? given.Length - consumed 
                             : chunkSize;
                pieces.Add(new string(g, consumed, toTake));
            }
            consumed += chunkSize;
        }
        return pieces;
    }
