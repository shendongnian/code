request.OnBeforeDeserialization = resp => {
    if (resp.RawBytes.Length >= 3 && resp.RawBytes[0] == 0xEF && resp.RawBytes[1] == 0xBB && resp.RawBytes[2] == 0xBF)
    {
        // Copy the data but with the UTF-8 BOM removed.
        var newData = new byte[resp.RawBytes.Length - 3];
        Buffer.BlockCopy(resp.RawBytes, 3, newData, 0, newData.Length);
        resp.RawBytes = newData;
        // Force re-conversion to string on next access
        resp.Content = null;
    }
};
Setting `resp.Content` to `null` is there as a safety guard, as `RawBytes` is only converted to a string if `Content` isn't already set to a value.
