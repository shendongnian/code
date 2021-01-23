        static void Main(string[] argv)
        {
            //128 Hex characters for the validation key, 64 for the AES decryption key
            int hexLengthForEncryption = 128;
            string validationKey = Generate_New_Key(hexLengthForEncryption, argv);
            hexLengthForEncryption = 64;
            string decryptionKey = Generate_New_Key(hexLengthForEncryption, argv);
            string[] originalKeys = new string[2] {validationKey, decryptionKey};
            Generate_File(originalKeys);
            Console.WriteLine("The file has been generated. Would you like to generate new keys in a new file?");
            string yorn = Console.ReadLine();
            while ((yorn != "N") && (yorn != "n") && (yorn != "no") && (yorn != "No"))
            {               
                hexLengthForEncryption = 128;
                validationKey = Generate_New_Key(hexLengthForEncryption, argv);
                hexLengthForEncryption = 64;
                decryptionKey = Generate_New_Key(hexLengthForEncryption, argv);
                string[] freshLines = new string[2]{validationKey, decryptionKey};
                Generate_File(freshLines);
                Console.WriteLine("The file has been generated. Would you like to generate new keys to a new file?");
                yorn = Console.ReadLine();
            }
        }
