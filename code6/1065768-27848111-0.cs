    public async Task<string> GetStringAsync(string IdArchivo)
    {
        string FinalData = await Task.Factory.StartNew(() =>
            {
                string NData = string.Empty;
                Byte[] BData = GetBinaryData(IdArchivo);
                string SData = Encoding.UTF8.GetString(BData);
                for (int i = 0; i < SData.Length; i++)
                {
                    if (i > 0)
                        i++;
                    if (i <= SData.Length - 1)
                        NData += SData[i];
                }
                return NData;
            });
        return FinalData;
    }
        
    public Byte[] GetBinaryData()
    {
        // Just retrieve the file from my database 
    }
