    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    
    namespace csharp
    {
        class Program
        {
            public static string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
    
            static void Main(string[] args)
            {
                //string mg = MD5Hash("john");
                bool inp = false;
                string hash;
                while (!inp) {
                    Console.WriteLine("Please input the hash you're trying to bruteforce...");
                    hash = Console.ReadLine();
                    if (hash.Length == 32) {
                        inp = true;
                        Console.WriteLine("Cracked! There you go: " + startProcess(hash));
                        Console.ReadLine();
                    }
                }
            }
            public static string startProcess(string hsh) {
                bool solved = false;
                string track = letters[0];
                string ltrack = letters[letters.Length - 1];
                while (!solved) {
    		        //Console.WriteLine(track); // remove this line for debug
                    track = setLCharPos(track, ltrack);
                    if (MD5Hash(track) == hsh) {
                        solved = true;
                        return track;
                    }
                } return track;
            }
            public static string setLCharPos(string ttr, string ltr) {
    
                if (ttr == "") return letters[0];
    
                if (ttr[ttr.Length - 1].ToString() != ltr) {
                    return ttr.Substring(0, ttr.Length - 1) + letters[Array.IndexOf(letters, ttr[ttr.Length - 1].ToString()) + 1];
                } else {
                    return setLCharPos(ttr.Substring(0, ttr.Length - 1), ltr) + letters[0];
                }
            }
            public static string MD5Hash(string text)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
    
                //compute hash from the bytes of text
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
    
                //get hash result after compute it
                byte[] result = md5.Hash;
    
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    //change it into 2 hexadecimal digits
                    //for each byte
                    strBuilder.Append(result[i].ToString("x2"));
                }
    
                return strBuilder.ToString();
            }
        }
    }
