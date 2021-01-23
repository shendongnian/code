    static void WriteTree(ProtoReader reader)
    {
        while (reader.ReadFieldHeader() > 0)
        {
            Console.WriteLine(reader.FieldNumber);
            Console.WriteLine(reader.WireType);
            switch (reader.WireType)
            {
                case WireType.Variant:
                    // warning: this appear to be wrong if the 
                    // value was written signed ("zigzag") - to
                    // read zigzag, add: pr.Hint(WireType.SignedVariant);
                    Console.WriteLine(reader.ReadInt64());
                    break;
                case WireType.String:
                    // note: "string" here just means "some bytes"; could
                    // be UTF-8, could be a BLOB, could be a "packed array",
                    // or could be sub-object(s); showing UTF-8 for simplicity
                    Console.WriteLine(reader.ReadString());
                    break;
                case WireType.Fixed32:
                    // could be an integer, but probably floating point
                    Console.WriteLine(reader.ReadSingle());
                    break;
                case WireType.Fixed64:
                    // could be an integer, but probably floating point
                    Console.WriteLine(reader.ReadDouble());
                    break;
                case WireType.StartGroup:
                    // one of 2 sub-object formats
                    var tok = ProtoReader.StartSubItem(reader);
                    WriteTree(reader);
                    ProtoReader.EndSubItem(tok, reader);
                    break;
                default:
                    reader.SkipField();
                    break;
            }
        }
    }
