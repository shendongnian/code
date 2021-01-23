    public static Guid GenerateTimeBasedGuid(DateTime dateTime)  
    {
        long ticks = dateTime.Ticks - GregorianCalendarStart.Ticks;
        byte[] guid = new byte[ByteArraySize];
        byte[] clockSequenceBytes = BitConverter.GetBytes(Convert.ToInt16(Environment.TickCount % Int16.MaxValue));
        byte[] timestamp = BitConverter.GetBytes(ticks);
        // copy node
        Array.Copy(Node, 0, guid, NodeByte, Node.Length);
        // copy clock sequence
        Array.Copy(clockSequenceBytes, 0, guid, GuidClockSequenceByte, clockSequenceBytes.Length);
        // copy timestamp
        Array.Copy(timestamp, 0, guid, 0, timestamp.Length);
        // set the variant
        guid[VariantByte] &= (byte)VariantByteMask;
        guid[VariantByte] |= (byte)VariantByteShift;
        // set the version
        guid[VersionByte] &= (byte)VersionByteMask;
        guid[VersionByte] |= (byte)((int)GuidVersion.TimeBased << VersionByteShift);
        return new Guid(guid);
    }
