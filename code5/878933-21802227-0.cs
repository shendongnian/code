    try
    {
        var hashBytes = rsa.SignData(stream, new SHA256CryptoServiceProvider());
        File.WriteAllBytes(Program.modPath + "default.rf-modsignature", hashBytes);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        throw;
    }
