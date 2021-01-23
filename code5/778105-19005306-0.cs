    using (var file = new FileStream(path + "/cen_18-2_-1-y11.xml", FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
    using (XmlReader r = XmlReader.Create(file, new XmlReaderSettings() { Async = true }))
    {
        while (await r.ReadAsync())
        {
            switch (r.NodeType)
            {
                case XmlNodeType.Text:
                    Console.WriteLine(await r.GetValueAsync());
                    break;
            }
        }
    }
