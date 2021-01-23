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
        var twoCharacterBuffer = new StringBuilder();
        var oneByte = new byte[1];
        foreach (var character in hexString.Where(c => c != ' '))
        {
            twoCharacterBuffer.Append(character);
            if (twoCharacterBuffer.Length == 2)
            {
                oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);
                stream.Write(oneByte, 0, 1);
                twoCharacterBuffer.Clear();
            }
        }
    }
