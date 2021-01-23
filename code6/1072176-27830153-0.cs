    using System;
    using System.IO;
    namespace RegisterUsers
    {
        class Program
        {
            static void AppendToFile(string file, string value)
            {
                using (TextWriter writer = new StreamWriter(file, true))
                {
                    writer.WriteLine(value);
                }
            }
            static void Register(string userFile, string passwordFile, string userName, string password)
            {
                AppendToFile(userFile, userName);
                AppendToFile(passwordFile, password);
            }
            static string[] GetLines(string file)
            {
                string[] result = null;
                using (TextReader reader = new StreamReader(file))
                {
                    result = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                }
                return result;
            }
            static bool TryLogin(string userFile, string passwordFile, string username, string password)
            {
                string[] userArray = GetLines(userFile);
                int index = -1, length = userArray.Length;
                for (int x = 0; x < length; x++)
                {
                    if (string.Equals(userArray[x], username))
                    {
                        index = x;
                        break;
                    }
                }
                if (index < 0)
                {
                    // no username found that matches your requirement
                    return false;
                }
                string[] passArray = GetLines(passwordFile);
                if (index > passArray.Length)
                {
                    // inconsistency, shouldn't happen...
                    return false;
                }
                return string.Equals(passArray[index], password);
            }
            static void Main(string[] args)
            {
                // keep the filenames, don't have to repeat them all the time
                string usernameFile = Path.Combine(Environment.CurrentDirectory, "UserFile.txt");
                string passwordFile = Path.Combine(Environment.CurrentDirectory, "PassFile.txt");
                // register 2 users, one with falsely typed testUser2 as tesetUser2
                Register(usernameFile, passwordFile, "testUser1", "password1");
                Register(usernameFile, passwordFile, "tesetUser2", "password15");
                // try to login with the testUser1 should work
                if (TryLogin(usernameFile, passwordFile, "testUser1", "password1"))
                {
                    Console.WriteLine("Login succesfull");
                }
                else
                {
                    Console.WriteLine("Login failed!");
                }
                // try to login with testUser2 shouldn't work (now correctly typed)
                if (TryLogin(usernameFile, passwordFile, "testUser2", "password15"))
                {
                    Console.WriteLine("Login succesfull");
                }
                else
                {
                    Console.WriteLine("Login failed!");
                }
                Console.ReadLine();
            }
        }
    }
