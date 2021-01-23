    byte[] bytes = new byte[]{byteValueOfYourCharacter};
            string UTF8 = Encoding.UTF8.GetString(bytes);
            Console.OutputEncoding = Encoding.UTF8;
   
            Console.WriteLine(UTF8);
            Console.ReadLine();
