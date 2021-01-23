    try
    {
        var stream = new FileStream(
            save_log.FileName,
            FileMode.Create,
            FileAccess.ReadWrite);
        WriteHexStringToFile(Content.Text, stream);
        stream.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    private void WriteHexStringToFile(string hexString, FileStream stream)
    {
        var twoCharacterBuffer = string.Empty;
        foreach (var character in hexString.Where(c => c != ' '))
        {
            twoCharacterBuffer += character;
            if (twoCharacterBuffer.Length == 2)
            {
                var oneByte = new[] { (byte)Convert.ToByte(twoCharacterBuffer, 16) };
                stream.Write(oneByte, 0, 1);
                twoCharacterBuffer = string.Empty;
            }
        }
    }
