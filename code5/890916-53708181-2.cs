        public static byte[] EncryptOrDecrypt(byte[] text, byte[] key)
        {
            string xorStr = "";
            for (int i = 0; i < text.Length; i++)
            {
                xorStr += (char)(text[i] ^ key[i % key.Length]);
            }
            string[] newStrArray = xorStr.Split('\0');
            xorStr = string.Join("", newStrArray);
            return Encoding.Unicode.GetBytes(xorStr);
        }
        static void Main(string[] args){
            string input;
            byte[] inputBytes;
            string inputKey;
            byte[] key;
            do
            {
                input = System.Console.ReadLine(); 
                inputBytes = Encoding.Unicode.GetBytes(input);
                inputKey = System.Console.ReadLine(); 
                key = Encoding.Unicode.GetBytes(inputKey);
                //byte[] key = { 0, 0 }; if key is 0, encryption will not happen
                byte[] cyptBytes = EncryptOrDecrypt(inputBytes, key);
                string cryptStr = Encoding.Unicode.GetString(cyptBytes);
                byte[] decrypBytes = EncryptOrDecrypt(cyptBytes, key);
                string decryptStr = Encoding.Unicode.GetString(decrypBytes);
                System.Console.WriteLine("Crypt string:");
                System.Console.WriteLine(cryptStr);
                System.Console.WriteLine("Decrypt string:");
                System.Console.WriteLine(decryptStr);
            } while (input != "-1" && inputKey != "-1");
            //test:
            //pavle
            //23
            //Crypt string:
            //BRD_W
            //Decrypt string:
            //pavle
        }
