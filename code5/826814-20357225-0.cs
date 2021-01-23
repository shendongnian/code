    using System.IO;
    using System.Security.Cryptography;
...
    const string fontFileName = "segoeuib.ttf";
    const string fontHash = "eXgZILEF1+jbMACnatG7CjtPpnhpeyebp4+q/K4fa2c/ig5aPPqTkVg5pNVNwtdYAENsziieZDbHWQHjaT791g==";
    static bool FontIsInstalled()
    {
        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontFileName);
        if (!File.Exists(fontPath)) return false;
        using (SHA512Managed sha = new SHA512Managed())
        {
            return fontHash.Equals(Convert.ToBase64String(sha.ComputeHash(File.ReadAllBytes(fontPath))));
        }
    }
