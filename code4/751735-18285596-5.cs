    using (var br = new BinaryReader(ms))
    {
        //byte b = BinaryReader<bool>.Read(br);
        //double d = BinaryReader<double>.Read(br);
        //string s = BinaryReader<string>.Read(br);
        // Or
        byte b = br.Read<bool>();
        double d = br.Read<double>();
        string s = br.Read<string>();
    }
