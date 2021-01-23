    public static Tuple<List<string>, List<string>> GenerateUniqueList(int count)
        {
            uniqueHashTable = new Hashtable();
            nonUniqueList = new List<string>();
            uniqueList = new List<string>();
            for (int i = 0; i < count; i++)
            {
                isUniqueGenerated = false;
                while (!isUniqueGenerated)
                {
                    uniqueStr = GetUniqueKey();
                    try
                    {
                        uniqueHashTable.Add(uniqueStr, "");
                        isUniqueGenerated = true;
                    }
                    catch (Exception ex)
                    {
                        nonUniqueList.Add(uniqueStr);
                        // Non-unique generated
                    }
                }
            }
            uniqueList = uniqueHashTable.Keys.Cast<string>().ToList();
            return new Tuple<List<string>, List<string>>(uniqueList, nonUniqueList);
        }
        public static string GetUniqueKey()
        {
            int size = 7;
            char[] chars = new char[62];
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
                result.Append(chars[b % (chars.Length - 1)]);
            return Convert.ToString(result);
        }
