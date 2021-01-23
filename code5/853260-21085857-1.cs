    using System.IO;
    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    class Program
    {
    	public static int PASSWORD_SHA512_ITERATIONS = 25000;
        public static string PASSWORD_BCRYPT_COST = "13";
        public static string PASSWORD_SALT = "/8Wncr26eAmxD1l6cAF9F8"; //22 characters to be appended on first 7 characters that will be generated using PASSWORD_ info above
                
        static void Main()
        {
                Console.WriteLine(getPasswordHash("test"));
        }
        
        public static string getPasswordHash(string password)
        {
        	    string salt = "$2a$" + PASSWORD_BCRYPT_COST + "$" + PASSWORD_SALT;
                string newPassword = password;
                SHA512 alg = SHA512.Create();
                for(int i = 0; i < PASSWORD_SHA512_ITERATIONS; i++) {
                  byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(salt+newPassword+salt));
                  newPassword = Encoding.UTF8.GetString(result);
                }
                return newPassword;
        }
    }
