    byte[] subArray = { 0x00, 0x01, 0x00, 0x01 }; 
    byte[] array = { 0x1A, 0x65, 0x3E, 0x00, 0x01, 0x00, 0x01, 0x2B, 0x4C, 0xAA };
    var matchIndexes =
        from index in Enumerable.Range(0, array.Length - subArray.Length + 1)
        where array.Skip(index).Take(subArray.Length).SequenceEqual(subArray)
        select (int?)index;
    var matchIndex = matchIndexes.FirstOrDefault();
    if (matchIndex != null)
    {
        byte[] successor = array.Skip(matchIndex.Value + subArray.Length).ToArray();
        // handle successor here
    }
