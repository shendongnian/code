    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO.Packaging;
    namespace ZipTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Block size we apply to all reads / writes
                const int BLOCK_SIZE = 65536;
                // The zip file we're using
                var zipFileName = @"C:\temp\ZipSO\MyZip.zip";
                // Password for encryption
                var password = "ThisIsMyPassword";
                // Name of temp file where we'll encrypt the file first
                var intermediateFile = @"C:\temp\ZipSO\Intermediate_" + Guid.NewGuid().ToString();
                // File we're encrypting / adding to archive
                var inputFile = @"C:\temp\ZipSO\InputFile.txt";
                // Salt for encryption
                var salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                // For the new / existing package part
                PackagePart part = null;
                // Open the archive
                using (var zip = Package.Open(zipFileName, System.IO.FileMode.OpenOrCreate))
                {
                    // Uri for the part
                    var uri = PackUriHelper.CreatePartUri(new Uri("/files/test.enc", UriKind.Relative));
                    // Get existing part if found, or create new
                    if (zip.PartExists(uri))
                        part = zip.GetPart(uri);
                    else
                        part = zip.CreatePart(uri, "", CompressionOption.Maximum);
                    // Encrypt the file first
                    var passBytes = System.Text.Encoding.ASCII.GetBytes(password);
                    using (var fs = new System.IO.FileStream(intermediateFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
                    {
                        var key = new System.Security.Cryptography.Rfc2898DeriveBytes(passBytes, salt, 1000);
                        var keySize = 256;
                        var blockSize = 128;
                    
                        var aes = new System.Security.Cryptography.RijndaelManaged()
                        {
                            KeySize = keySize,
                            BlockSize = blockSize,
                            Key = key.GetBytes(keySize / 8),
                            IV = key.GetBytes(blockSize / 8),
                            Padding = System.Security.Cryptography.PaddingMode.Zeros,
                            Mode = System.Security.Cryptography.CipherMode.CBC
                        };
                        using (var fsSource = new System.IO.FileStream(inputFile, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            using (var cs = new System.Security.Cryptography.CryptoStream(fs, aes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                            {
                                var readBytes = new byte[BLOCK_SIZE];
                                int read;
                                while ((read = fsSource.Read(readBytes, 0, BLOCK_SIZE)) != 0)
                                {
                                    cs.Write(readBytes, 0, read);
                                }
                                cs.Close();
                            }
                            fsSource.Close();
                        }
                        fs.Close();
                    }
                    // Now add it to the archive
                    using (var p = part.GetStream(System.IO.FileMode.OpenOrCreate))
                    {
                        using (var source = new System.IO.FileStream(intermediateFile, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        using (var bw = new System.IO.BinaryWriter(p))
                        {
                            var readBytes = new byte[BLOCK_SIZE];
                            int read;
                            while ((read = source.Read(readBytes, 0, BLOCK_SIZE)) != 0)
                            {
                                bw.Write(readBytes.Take(read).ToArray());
                            }
                        }
                    }
                }
            }
        }
    }
