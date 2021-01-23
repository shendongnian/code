    using System.IO;
    using System.Security.Cryptography;
...
    const string fontFileName = "seguisym.ttf";
    const string fontHash = "/O7kUQinASYq8BG6dSY4YXkXQcbCeZQOmAcaWQqPP60OcgbGpXR5+yNug0pceicfHpjxV+6sdmy1j8Np2VIbOQ==";
    static bool FontIsInstalled()
    {
        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontFileName);
        if (!File.Exists(fontPath)) return false;
        using (SHA512Managed sha = new SHA512Managed())
        {
            return fontHash.Equals(Convert.ToBase64String(sha.ComputeHash(File.ReadAllBytes(fontPath))));
        }
    }
