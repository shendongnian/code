    public static Page ReadPage(BinaryReader reader)
    {
        Page page;
        page.prev = reader.ReadUInt32();
        page.next = reader.ReadUInt32();
        ushort count = reader.ReadUInt16();
        page.items = new Row[count];
        for (int i=0; i<count; i++)
        {
            page.items[i].id = reader.ReadUInt32();
            page.items[i].name = Encoding.ASCII.GetString(reader.ReadBytes(256));
        }
        // skip past the unused rows
        reader.ReadBytes((256+sizeof(uint))*(256-count)); 
    }
        
