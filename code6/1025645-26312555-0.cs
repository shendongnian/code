    static string encrypt(string text, int key)
    {
        string ciphertext = "";
        char[] letters = text.ToCharArray();
        for (int x = 0; x < letters.Length; x++) // see 1
        {
            int AsciiLET = (int)letters[x]; //2
            char Asciiletter = (char)(AsciiLET + key); //3 & 4
            ciphertext += Asciiletter;
        }
        return ciphertext;
    }
