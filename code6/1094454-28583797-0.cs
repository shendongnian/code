    private static IEnumerable<byte[]> EnumerateSegments(byte[] input)
    {
        var i = 0;
        while (i + 15 < input.Length)
        {
            // check if it starts with 'sync' bytes
            // (not sure which is the second one, though?)
            var cookie = input[i];
            if (input[i] != 0x55 || input[i + 1] != 0xAA)
            {
                i++;
                continue;
            }
            // get the 16-bit checksum
            // (check if this is the correct endian, i.e. you
            // might need to swap bytes)
            var receivedChecksum = (input[i + 2] << 8) | (input[i + 3]);
                
            // calculate the checksum over data only
            var calculatedChecksum = CalculateChecksum(input, i + 4, 12);
            if (receivedChecksum != calculatedChecksum)
            {
                i++;
                continue;
            }
            // if we're here, data should be valid, so the last
            // thing left to do is to copy the data into the subarray
            var segment = new byte[12];
            Array.Copy(input, i + 4, segment, 0, 12);
            yield return segment;
            // skip this segment
            i += 16;
        }
    }
