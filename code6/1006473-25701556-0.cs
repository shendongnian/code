    public class ClassOneToNumberOneBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            typeName = typeName.Replace(
                "MyNamespace.ClassOne",
                "MyNamespace.Class.NumberOne");
            assemblyName = assemblyName.Replace("MyNamespace", "MyNamespace.Class");
            return Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
        }
    }
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    binaryFormatter.Binder = new ClassOneToNumberOneBinder();
