    _sbScript.Append("0x");
    for (int i = 0; i < buffer.Length; i++)
    {
        _sbScript.Append(buffer[i].ToString("X2",System.Globalization.CultureInfo.InvariantCulture));
    }
