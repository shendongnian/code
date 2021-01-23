    /* using declarations:
    using System;
    using System.IO;
    using System.Security.Cryptography;
    */
    static string ComputeFileChecksum(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (var fileStream = File.OpenRead(filePath))
            using (var sha256 = new SHA256CryptoServiceProvider())
            {
                var hashBytes = sha256.ComputeHash(fileStream);
                return Convert.ToBase64String(hashBytes);
            }
        }
        else
        {
            // TODO: handle non-existent file
            return string.Empty;
        }
    }
