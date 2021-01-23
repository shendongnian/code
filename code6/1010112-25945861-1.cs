        static void Main(string[] args)
        {
            var assemblyPath = @"lib\TestC.exe"; //only Testc.exe here not dependent assemblies
            var typeFullname = "TestC.MyClass";
            var attributeFullName = "OptionX.MyXAttribute";
            var assembly = AssemblyDefinition.ReadAssembly(assemblyPath);
            var type=assembly.MainModule.Types.First(t => t.FullName == typeFullname);
            var attributes=type.CustomAttributes.Where(a => a.AttributeType.FullName == attributeFullName).ToList();
            if (attributes.Count == 0)
            {
                //type is not decorated with attribute
                return;
            }
            Console.WriteLine("Args");
            foreach (var a in attributes)
                foreach(var arg in a.ConstructorArguments)
                    Console.WriteLine("{0}: {1}",arg.Type.Name,arg.Value);
            Console.WriteLine("Properties");
            foreach(var a in attributes)
                foreach(var p in a.Properties)
                    Console.WriteLine("{0}: {1}",p.Name,p.Argument.Value);
        }
