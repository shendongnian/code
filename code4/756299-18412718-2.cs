    static string Encr(string plainText, string key)
    {
        char[] chars = new char[plainText.Length];
        int h = 0;
        for (int i = 0; i < plainText.Length; i++)
        {
            if (h == key.Length)
                h = 0;
            int j = plainText[i] + key[h];
            chars[i] = (char)j;
            h++;
        }
        File.WriteAllBytes(FILE_NAME, System.Text.Encoding.UTF8.GetBytes(chars));
        return new String(chars, System.Text.Encoding.UTF8);
    }
