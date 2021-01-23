    foreach (var kvp in enteries)
    {
        IgaAdKey = kvp.Key;
        IgaEntry entry = kvp.Value;
        streamWriter.Write(adKey.LocationId + ",");
        streamWriter.Write(adKey.EditionId + ",");
        streamWriter.Write(entry.mClickCount + ",");
        streamWriter.Write(entry.mViewCount + ",");
        streamWriter.Write(",");
    }
