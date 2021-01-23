    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Windows.Forms;
    
    namespace HashToClipboard
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                string hexHash = Hash(args[0]);
                string password = "~" + hexHash + "~";
                Clipboard.SetText(password);
            }
    
            static public string Hash(string path)
            {
                using (var stream = File.OpenRead(path))
                using (var hasher = MD5.Create())
                {
                    byte[] hash = hasher.ComputeHash(stream);
                    string hexHash = BitConverter.ToString(hash).Replace("-", "");
                    return hexHash;
                }
            }
        }
    }
