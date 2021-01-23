        public static void SplitArayUsingLinq()
        {
            int i = 3;
            string data = "123456789";
            byte[] largeBytes = Encoding.UTF8.GetBytes (data);
            byte[] first = largeBytes.Take(i).ToArray();
            byte[] second = largeBytes.Skip(i).ToArray();
            string firststring = Encoding.UTF8.GetString (first);
            string secondstring = Encoding.UTF8.GetString(second);
            Console.WriteLine(" first : " +firststring);
            Console.WriteLine(" second : " +secondstring);
        }
