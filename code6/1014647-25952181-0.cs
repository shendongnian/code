    static int? ReadNthArrayItem(Stream source, int index, int maxLen)
    {
        using (var reader = new ProtoReader(source, null, null, maxLen))
        {
            int field, count = 0;
            while ((field = reader.ReadFieldHeader()) > 0)
            {
                switch (field)
                {
                    case 2: // fat property; a sub object
                        var tok = ProtoReader.StartSubItem(reader);
                        while ((field = reader.ReadFieldHeader()) > 0)
                        {
                            switch (field)
                            {
                                case 1: // the array field
                                    if(count++ == index)
                                        return reader.ReadInt32();
                                    reader.SkipField();
                                    break;
                                default:
                                    reader.SkipField();
                                    break;
                            }
                        }
                        ProtoReader.EndSubItem(tok, reader);
                        break;
                    default:
                        reader.SkipField();
                        break;
                }
            }
        }
        return null;
    }
