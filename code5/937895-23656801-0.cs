    public static class Program
    {
        public static string ReverseString(this string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        static void Main(string[] args)
        {
            var pass = "12345678";
            byte[] salt = Encoding.ASCII.GetBytes(pass.ReverseString());
            //https://github.com/defuse/password-hashing/blob/master/PasswordHash.cs
            //was getting error salt not 8 byte,
            //http://stackoverflow.com/questions/1647481/what-is-the-c-sharp-equivalent-of-the-php-pack-function
            var hash = PasswordHash.PBKDF2(pass, salt, 1000, 16);
            Console.WriteLine(BitConverter.ToString(hash).Replace("-", string.Empty).ToLower());
            Console.ReadKey();
        }
    }
