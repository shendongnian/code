        public static string Decrypt(string inputPath)
        {
            FileStream input = new FileStream(inputPath, FileMode.Open);
            MemoryStream output = new MemoryStream();
            Decrypt(input, output);
            StreamReader reader = new StreamReader(output, new UTF8Encoding()); //Read with encoding
            output.Seek(0, SeekOrigin.Begin); //Set stream Position to beginning
            string result = reader.ReadToEnd(); //read to string
            reader.Close();
            input.Close();
            output.Close();
            return result;
        }
