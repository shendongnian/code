            int siteId = 1;
            DirectoryEntry objDirEntry = new DirectoryEntry(metabasePath);
            foreach (DirectoryEntry e in objDirEntry.Children)
            {
                if (e.SchemaClassName == "IIsWebServer")
                {
                    int id = Convert.ToInt32(e.Name);
                    if (id >= siteId)
                        siteId = id + 1;
                }
            }
            return siteId;
        }
