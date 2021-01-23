    int originalTagSize = IdSharp.Tagging.ID3v2.ID3v2Tag.GetTagSize(filename);
    
    byte[] tagBytes = tags.GetBytes(originalTagSize);
    
    if (tagBytes.Length < originalTagSize)
    {
        // Eventually this won't be a problem, but for now we won't worry about shrinking tags
        throw new Exception("GetBytes() returned a size less than the minimum size");
    }
    else if (tagBytes.Length > originalTagSize)
    {
        //In the original implementation is done with:
        //ByteUtils.ReplaceBytes(path, originalTagSize, tagBytes);
        //Maybe you should write a 'ReplaceBytes' method that accepts a stream
    }
    else
    {
        // Write tag of equal length
        ms.Write(tagBytes, 0, tagBytes.Length);
    }
