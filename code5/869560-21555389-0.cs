    public static IList<MethodBase> GetCalledMethods(MethodBase methodBase)
    {
        IList<MethodBase> calledMethods = new List<MethodBase>();
        var body = methodBase.GetMethodBody();
        Module module = Assembly.GetExecutingAssembly().ManifestModule;
        byte[] bytes = body.GetILAsByteArray();
        using (var stream = new MemoryStream(bytes))
        {
            long streamLength = stream.Length;
            using (var reader = new BinaryReader(stream))
            {
                while (reader.BaseStream.Position < streamLength)
                {
                    byte instruction = reader.ReadByte();
                    if (instruction == OpCodes.Call.Value
                        || instruction == OpCodes.Callvirt.Value
                        || instruction == OpCodes.Newobj.Value)
                    {
                        int token = reader.ReadInt32();
                        var method = module.ResolveMethod(token);
                        calledMethods.Add(method);
                    }
                }
            }
        }
    
        return calledMethods;
    }
