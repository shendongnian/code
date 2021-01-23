        public static string OpenStandardStreamIn()
        {
            //Read 4 bytes of length information
            System.IO.Stream stdin = Console.OpenStandardInput();
            int length = 0;
            byte[] bytes = new byte[4];
            stdin.Read(bytes, 0, 4);
            length = System.BitConverter.ToInt32(bytes, 0);
            char[] buffer = new char[length];
            using (System.IO.StreamReader sr = new System.IO.StreamReader(stdin))
            {
                while (sr.Peek() >= 0)
                {
                    sr.Read(buffer, 0, buffer.Length);
                }
            }
            string input = new string(buffer);
            return input;
        }
