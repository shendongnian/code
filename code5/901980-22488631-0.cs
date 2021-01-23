    var master = byte[] { /* your array of proper bytes */ };
    var buffer = byte[] { /* your incoming bytes */ };
    if (buffer.Length == master.Length)
    {
        for (var i = 0; i < master.Length; i++)
        {
            if (master[i] != buffer[i]) throw new ArgumentException("bad byte");
        }
    }
    else
    {
        throw new ArgumentException("malformed stream");
    }
    // continue dealing with the bytes as necessary
