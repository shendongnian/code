    public static string GetMachineId()
    {
        var hardwareToken = 
            HardwareIdentification.GetPackageSpecificToken(null).Id.ToArray();
        var count = hardwareToken.Length / 4;
        ulong id = 0ul;
        for (int i = 0; i < count; i++)
        {
            switch (BitConverter.ToUInt16(hardwareToken, i * 4))
            {
                case 1:
                    // processor
                case 2:
                    // memory
                case 9:
                    // system BIOS
                    id = (id << 12) ^ BitConverter.ToUInt16(hardwareToken, i * 4 + 2);
                    break;
            }
        }
        return Convert.ToBase64String(BitConverter.GetBytes(id));
    }
