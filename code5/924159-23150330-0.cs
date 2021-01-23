    public static string CalculateMD5Hash(string input)
    {
        using (MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
    static void Main(string[] args)
    {
        using (Mutex mutex = new Mutex(true, CalculateMD5Hash(args[0])))
        {
            if (mutex.WaitOne(100))
            {
                Console.WriteLine("First instance");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Second instance");
                Console.ReadKey();
            }
        }
    }
