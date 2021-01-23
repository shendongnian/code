            System.Reflection.Assembly assembly;
            assembly = System.Reflection.Assembly.Load("our.biztier");
            kernel.Load(assembly);
            assembly = System.Reflection.Assembly.Load("our.datatier");
            kernel.Load(assembly);
