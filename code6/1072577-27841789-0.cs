    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    namespace MvcWebRole1.Controllers
    {
        public class AESController : Controller
        {
            //
            // GET: /AES/
            public ActionResult Index()
            {
                ViewData["Encrypted"] = TempData["TEncrypted"];
                ViewData["Decrypted"] = TempData["TDecrypted"];
                return View();
                
            }
            //Text is PlainText
            //Key is Public Secret Key 
            [HttpPost]
            public ActionResult Encryption(string Text, string Key)
            {
                // Convert String to Byte
                byte[] MsgBytes = Encoding.UTF8.GetBytes(Text);
                byte[] KeyBytes = Encoding.UTF8.GetBytes(Key);
                // Hash the password with SHA256
                //Secure Hash Algorithm
                //Operation And, Xor, Rot,Add (mod 232),Or, Shr
                //block size 1024
                //Rounds 80
                //rotation operator , rotates point1 to point2 by theta1=> p2=rot(t1)p1
                //SHR shift to right
                KeyBytes = SHA256.Create().ComputeHash(KeyBytes);
                byte[] bytesEncrypted = AES_Encryption(MsgBytes, KeyBytes);
                string encryptionText = Convert.ToBase64String(bytesEncrypted);
                TempData["TEncrypted"] = encryptionText;
                return RedirectToAction("Index");
            }
            public byte[] AES_Encryption(byte[] Msg, byte[] Key)
            {
                byte[] encryptedBytes = null;
                //salt is generated randomly as an additional number to hash password or message in order o dictionary attack
                //against pre computed rainbow table
                //dictionary attack is a systematic way to test all of possibilities words in dictionary wheather or not is true?
                //to find decryption key
                //rainbow table is precomputed key for cracking password
                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.  == 16 bits
                byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {
                        AES.KeySize = 256;
                        AES.BlockSize = 128;
                        var key = new Rfc2898DeriveBytes(Key, saltBytes, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);
                        AES.Mode = CipherMode.CBC;
                        using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(Msg, 0, Msg.Length);
                            cs.Close();
                        }
                        encryptedBytes = ms.ToArray();
                    }
                }
                return encryptedBytes;
            }
            [HttpPost]
            public ActionResult Decryption(string Text2, string Key2)
            {
                // Convert String to Byte
                byte[] MsgBytes = Convert.FromBase64String(Text2);
                byte[] KeyBytes = Encoding.UTF8.GetBytes(Key2);
                KeyBytes = SHA256.Create().ComputeHash(KeyBytes);
                byte[] bytesDecrypted = AES_Decryption(MsgBytes, KeyBytes);
                string decryptionText = Encoding.UTF8.GetString(bytesDecrypted);
                TempData["TDecrypted"] = decryptionText;
                return RedirectToAction("Index");
            }
            public byte[] AES_Decryption(byte[] Msg, byte[] Key)
            {
                byte[] decryptedBytes = null;
                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.
                byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {
                        AES.KeySize = 256;
                        AES.BlockSize = 128;
                        var key = new Rfc2898DeriveBytes(Key, saltBytes, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);
                        AES.Mode = CipherMode.CBC;
                        using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(Msg, 0, Msg.Length);
                            cs.Close();
                        }
                        decryptedBytes = ms.ToArray();
                    }
                }
                return decryptedBytes;
            }
        }
    }
