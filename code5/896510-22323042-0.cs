    // calculate the checksum
    ushort checksum = XYClassName.ComputeHeaderIpChecksum(arr, 0, arr.Length);
    // create header from checksum and data
    byte[] header = new byte[arr.Length + 2];
    Array.Copy(arr, 0, header, 2, arr.Length);
    header[0] = checksum >> 8; // high byte first
    header[1] = checksum & 0xff; // low byte 2nd
