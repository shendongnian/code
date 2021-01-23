    static void Main(string[] args)
        {
            string line = string.Empty;
            System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\test.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\test.hack");
            while ((line = reader.ReadLine()) != null) // Read until there is nothing more to read
            {
                if (line.StartsWith("@"))
                {
                    line = line.Remove(0, 1); // Remove '@'
                }
                int value = -1;
                if (Int32.TryParse(line, out value)) // Check if the rest string is an integer
                {
                    // Convert the rest string to its binary representation and write it to the file
                    writer.WriteLine(intToBinary(value));
                }
                else
                {
                    // Couldn't convert the string to an integer..
                }
            }
            reader.Close();
            writer.Close();
            Console.WriteLine("Done!");
            Console.Read();
        }
        //http://www.dotnetperls.com/binary-representation
        static string intToBinary(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;
            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }
