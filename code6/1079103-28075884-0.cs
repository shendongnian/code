    void ReplaceTextInFile(string fileName, string oldText, string newText)
    {
        byte[] fileBytes = File.ReadAllBytes(fileName),
            oldBytes = Encoding.UTF8.GetBytes(oldText),
            newBytes = Encoding.UTF8.GetBytes(newText);
        int index = IndexOfBytes(fileBytes, oldBytes);
        if (index < 0)
        {
            // Text was not found
            return;
        }
        byte[] newFileBytes =
            new byte[fileBytes.Length + newBytes.Length - oldBytes.Length];
        Buffer.BlockCopy(fileBytes, 0, newFileBytes, 0, index);
        Buffer.BlockCopy(newBytes, 0, newFileBytes, index, newBytes.Length);
        Buffer.BlockCopy(fileBytes, index + oldBytes.Length,
            newFileBytes, index + newBytes.Length,
            fileBytes.Length - index - oldBytes.Length);
        File.WriteAllBytes(filename, newFileBytes);
    }
    int IndexOfBytes(byte[] searchBuffer, byte[] bytesToFind)
    {
        for (int i = 0; i < searchBuffer.Length - bytesToFind.Length; i++)
        {
            bool success = true;
            for (int j = 0; j < bytesToFind.Length; j++)
            {
                if (searchBuffer[i + j] != bytesToFind[j])
                {
                    success = false;
                    break;
                }
            }
            if (success)
            {
                return i;
            }
        }
        return -1;
    }
