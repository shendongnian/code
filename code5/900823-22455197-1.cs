    string fileContents;
    try
    {
        using (FileStream fs = new FileStream(Path.Combine(sourceFile, t), FileMode.Open, FileAccess.Read, FileShare.Read))
        using (StreamReader reader = new StreamReader(fs))
        {
            fileContents = reader.ReadToEnd();
        }
    }
    catch (IOException)
    {
        p.Kill();
        p.WaitForExit(1000);
        goto I;
    }
