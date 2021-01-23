    //
    // Summary:
    //     Reads a line of characters from the current stream and returns the data as
    //     a string.
    //
    // Returns:
    //     The next line from the input stream, or null if the end of the input stream
    //     is reached.
    //
    // Exceptions:
    //   System.OutOfMemoryException:
    //     There is insufficient memory to allocate a buffer for the returned string.
    //
    //   System.IO.IOException:
    //     An I/O error occurs.
    public override string ReadLine();
