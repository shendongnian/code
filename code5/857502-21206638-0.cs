    using System.Security.Cryptography;
    using System.Text;
    string str = "foobar";
    byte[] data = Encoding.ASCII.GetBytes(str);
    SHA1 sha = new SHA1Managed();
    byte[] hash = sha.ComputeHash(data);
    Console.WriteLine(String.Concat(Array.ConvertAll(hash, x => x.ToString("X2"))));
