    static string FormatSerialNumber(string serialNumber)
    {
        var parts = serialNumber.Split('-');
        parts[2] = parts[2].TrimStart('0');
        return string.Join("-", parts);
    }
    // Call it like this:
    FormatSerialNumber("BMS21-14-000000000000000000120") // BMS21-14-120
