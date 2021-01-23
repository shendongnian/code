        void Test()
        {
            string pwd = "Testing1234";
            string user = "username";
            StorePassword(user, pwd);
            bool result = ValidatePassword(user, pwd);
            if (result == true) Console.WriteLine("Match!!");
        }
        private void StorePassword(string username, string password)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var salt = new string(
                Enumerable.Repeat(chars, 8)
                       .Select(s => s[random.Next(s.Length)])
                       .ToArray());
            string hash = GetHash(salt + password);
            string saltedHash = salt + ":" + hash;
            string[] credentials = new string[] { username, saltedHash };
            System.IO.File.WriteAllLines(@"D:\C#\test.txt",credentials);
        }
        bool ValidatePassword(string username, string password)
        {
            string[] content = System.IO.File.ReadAllLines(@"D:\C#\test.txt");
            
            if (username != content[0]) return false; //Wrong username
            string[] saltAndHash = content[1].Split(':'); //The salt will be stored att index 0 and the hash we are testing against will be stored at index 1.
            string hash = GetHash(saltAndHash[0] + password);
            if (hash == saltAndHash[1]) return true;
            else return false;
                
        }
        string GetHash(string input)
        {
            System.Security.Cryptography.SHA256Managed hasher = new System.Security.Cryptography.SHA256Managed();
            byte[] bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    
