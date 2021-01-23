        sealed class MyAsemblyBinder : System.Runtime.Serialization.SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                string myAsm = System.Reflection.Assembly.GetExecutingAssembly().FullName;
                Type foundType = Type.GetType(String.Format("{0}, {1}", typeName, myAsm));
                if (foundType == null)
                    foundType = typeof(Object);
                return foundType;
            }
        }
