    class Program
    {
        static void Main(string[] args)
        {
            // I have a post build step that copies the B.dll to this sub directory.
            // but the B.dll also lives in the main directory alongside the exe:
            // mkdir LoadFrom
            // copy B.dll LoadFrom
            //
            var loadFromAssembly = Assembly.LoadFrom(@".\LoadFrom\B.dll");
            var mySerializableType = loadFromAssembly.GetType("B.MySerializable");
            object mySerializableObject = Activator.CreateInstance(mySerializableType);
            var copyMeBySerializationMethodInfo = mySerializableType.GetMethod("CopyMeBySerialization");
            try
            {
                copyMeBySerializationMethodInfo.Invoke(mySerializableObject, null);
            }
            catch (TargetInvocationException tie)
            {
                Console.WriteLine(tie.InnerException.ToString());
            }
            Console.ReadKey();
        }
    }
