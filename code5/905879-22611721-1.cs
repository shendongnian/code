    byte[] nameBytes = System.Text.Encoding.Unicode.GetBytes(adapterName + '\0');
    fixed (byte* pName = &nameBytes[0])
    {
        queryOID.ptcDeviceName = pName;
        queryOID.Oid = (uint)oid;
        var bytes = queryOID.getBytes();
        ndis.DeviceIoControl(IOCTL_NDISUIO_QUERY_OID_VALUE, bytes, bytes);
        var result = new byte[queryOID.Data.Length];
        Buffer.BlockCopy(queryOID.Data, 0, result, 0, result.Length);
    }
