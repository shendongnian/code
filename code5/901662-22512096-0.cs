    var name = "PCI\\Manixx1\0";
    var nameBytes = Encoding.Unicode.GetBytes(name);
    myStruct.ptcDeviceName = Marshal.AllocHGlobal(nameBytes.Length);
    try
    {
        Marshal.Copy(nameBytes, 0, myStruct.ptcDeviceName, nameBytes.Length);
        // make the IOCTL call
    }
    finally
    {
        Marshal.FreeHGlobal(myStruct.ptcDeviceName);
    }
