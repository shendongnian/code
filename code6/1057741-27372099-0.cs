    string cData = File.ReadAllText(@file1Text.Text );
    DWORD rData;
    if (UInt32.TryParse(cData, out rData))
    {
        // If you get here, the data was valid and is now stored in rData
    }
    else
    {
        // If you get in here, the cData was not a valid UInt32
    }
