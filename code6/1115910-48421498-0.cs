    private void PrintGreekIsoText(BinaryWriter bw, string text)
    {
        // ESC t 15
        bw.Write("\x1bt\x15");
        // Convert the text to the appropriate encoding
        var isoEncoding = Encoding.GetEncoding(28597);
        var bytes = Encoding.Unicode.GetBytes(text);
        byte[] output = Encoding.Convert(Encoding.Unicode, isoEncoding, bytes);
        bw.Write(output);
    }
