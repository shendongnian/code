    class Binder : SerializationBinder
    {
        //WARNING: demonstration only, DO NOT USE in production code
        public override Type BindToType(string assemblyName, string typeName)
        {
            return Type.GetType("ClassA");
        }
    }
