    string str = "hello".Substring(0, 2); // force not to inline the string
                                          // it would be the same if it was inlined
    GCHandle h = GCHandle.Alloc(str, GCHandleType.Pinned);
    IntPtr ptr = h.AddrOfPinnedObject(); // Your address
    // ch is h
    // the unchecked is necessary (technically optional because it's default)
    // because Marshal.ReadInt16 reads a signed Int16, while char is more similar
    // to an unsigned Int16
    char ch = unchecked((char)Marshal.ReadInt16(ptr));
