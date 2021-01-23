    var provider = CodeDomProvider.CreateProvider("C#");
    string src=@"
        namespace x
        {
            using System;
            public class y
            {
                public void z()
                {
                    Console.WriteLine(""hello world"");
                }
            }
        }
    ";
    var result = provider.CompileAssemblyFromSource(new CompilerParameters(), src);
    if (result.Errors.Count == 0)
    {
        var type = result.CompiledAssembly.GetType("x.y");
        var instance = Activator.CreateInstance(type);
        type.GetMethod("z").Invoke(instance, null);
    }
