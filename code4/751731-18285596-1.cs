    using (var br = new BinaryReader(ms))
    {
        //var b = BinaryReader<bool>.Read(br);
        //var d = BinaryReader<double>.Read(br);
        //var s = BinaryReader<string>.Read(br);
        // Or
        var b = br.Read<bool>();
        var d = br.Read<double>();
        var s = br.Read<string>();
    }
