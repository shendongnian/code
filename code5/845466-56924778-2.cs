    /// <summary>
    /// Write a new config file
    /// </summary>
    /// <param name="xml">Xml of the new config file</param>
    /// <returns>Task</returns>
    public async Task UpdateConfig(string xml)
    {
        // Ensure valid xml before writing the file
        XmlDocument doc = new XmlDocument();
        using (XmlReader xmlReader = XmlReader.Create(new StringReader(xml), new XmlReaderSettings { CheckCharacters = false }))
        {
            doc.Load(xmlReader);
        }
        // ReaderWriterLock
        configLock.AcquireReaderLock(Timeout.Infinite);
        try
        {
            string text = await File.ReadAllTextAsync(ConfigFilePath).ConfigureAwait(true);
    
            // if the file changed, update it
            if (text != xml)
            {
                LockCookie cookie = configLock.UpgradeToWriterLock(Timeout.Infinite);
                try
                {
                    // compare again in case text was updated before write lock was acquired
                    if (text != xml)
                    {
                        await File.WriteAllTextAsync(ConfigFilePath, xml).ConfigureAwait(true);
                    }
                }
                finally
                {
                    configLock.DowngradeFromWriterLock(ref cookie);
                }
            }
        }
        finally
        {
            configLock.ReleaseReaderLock();
        }
    }
