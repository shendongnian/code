        private static void InjectAttribute<T>(string source,string destination,string nameSpace="")where T:Attribute
        {
            var assembly = AssemblyDefinition.ReadAssembly(source);
            var module = assembly.MainModule;
            var types = module.GetTypes();
            var attributeConstructor = module.Import(typeof (T).GetConstructor(Type.EmptyTypes));
            foreach (var type in types)
            {
                if (type.FullName.StartsWith(nameSpace))
                    type.CustomAttributes.Add(new CustomAttribute(attributeConstructor));
            }
            assembly.Write(destination);
        }
