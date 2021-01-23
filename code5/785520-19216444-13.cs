    public override int GetHashCode()
    {
        var hashCode = 0;
        var bytes = _fileHash.Union(Encoding.UTF8.GetBytes(_fileString)).ToArray();
        for (var i = 0; i < bytes.Length; i++)
            hashCode = (hashCode << 3) | (hashCode >> (29)) ^ bytes[i]; // Rotate by 3 bits and XOR the new value.
        return hashCode;
    }
