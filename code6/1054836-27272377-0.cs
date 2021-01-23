            static void Main(string[] args)
            {
                Console.Clear();
                Console.WriteLine("Creating New User");
                String Username, Password = string.Empty;
                Console.WriteLine("Enter The UserName");
                Username = Console.ReadLine();
                Console.WriteLine("Enter The Passwrod for the User");
                Password = Console.ReadLine();
                StreamWriter sw = new StreamWriter("D:/UserNameAndPassword.txt",true);
                sw.WriteLine(Username);
                sw.WriteLine(Password);
                sw.Close();
                Console.WriteLine("Done....");
            }
