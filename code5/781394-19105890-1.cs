    var output = new MemoryStream();
    TextWriter writer = new StreamWriter(output);
    foreach (var rawSegment in GetRawSegments(interchange))
    {
       writer.Write(rawSegment.ToString(interchange.ElementDelimeter, interchange.SegmentTerminator));
    }
    writer.Flush();
    
    return output;
