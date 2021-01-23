        private static void TestBC()
        {
            //Demo params
            string keyString = "jDxESdRrcYKmSZi7IOW4lw==";            
            string input = "abc";
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);            
            //Aes Encryption
            AesEngine engine = new AesEngine();
            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(engine);
            KeyParameter keyParam = new KeyParameter(Convert.FromBase64String(keyString));                        
            cipher.Init(true, keyParam);
            byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, outputBytes, 0);
            cipher.DoFinal(outputBytes, length); //Do the final block
            //Aes Decryption             
            cipher = new PaddedBufferedBlockCipher(new AesEngine());                                 
            cipher.Init(false, keyParam);
            byte[] comparisonBytes = new byte[cipher.GetOutputSize(outputBytes.Length)];
            length = cipher.ProcessBytes(outputBytes, comparisonBytes, 0);
            cipher.DoFinal(comparisonBytes, length); //Do the final block
            Console.WriteLine(Encoding.UTF8.GetString(comparisonBytes)); //Should be abc
        }
