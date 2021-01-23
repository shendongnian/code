    public static string Encrypt(bool encrypt, string word, int startKey, int multKey, int addKey)
    {
        try
        {
            StringBuilder encryptedWord = new StringBuilder(word.Length);
            for (int i = 0; i < word.Length; i++)
            {
                encryptedWord.Append((char)((byte)(word[i] ^ (startKey >> 8))));
                if(encrypt)
                    startKey = (((int)encryptedWord[i]) + startKey) * multKey + addKey;
                else
                    startKey = (((int)word[i]) + startKey) * multKey + addKey;
            }
            return encryptedWord.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }    
    }
