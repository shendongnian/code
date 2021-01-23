    string mdfFileName = args[0];
    if (!File.Exists(mdfFileName))
    {
        Console.WriteLine("ERROR: specified file does not exist!");
        return;
    }
    NameValueCollection mdfFileVersions = ConfigurationManager.GetSection("MdfFileVersions") as NameValueCollection;
    try
    {
        FileStream fs = new FileStream(mdfFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        BinaryReader reader = new BinaryReader(fs);
        // skip the first 0x12064 bytes
        reader.ReadBytes(0x12064);
        // read two bytes
        short fileVersion = reader.ReadInt16();
        string sqlServerVersion = string.Empty;
        if (mdfFileVersions != null)
        {
            sqlServerVersion = mdfFileVersions[fileVersion.ToString(CultureInfo.CurrentUICulture)];
            if (string.IsNullOrEmpty(sqlServerVersion))
            {
                sqlServerVersion = "unknown version";
            }
        }
        else
        {
            sqlServerVersion = "no version info available";
        }
        Console.WriteLine("Examined file: '{0}'", mdfFileName);
        Console.WriteLine("File version : {0} ({1})", fileVersion, sqlServerVersion);
    }
    catch (Exception exc)
    {
        Console.WriteLine("ERROR: cannot open specified MDF file");
        Console.WriteLine("\t{0}: {1}", exc.GetType().FullName, exc.Message);
    }
