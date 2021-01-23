    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using ICSharpCode.Decompiler;
    using ICSharpCode.ILSpy;
    using Mono.Cecil;
    class Foo { }
    class Program
    {
        static string classSourceCode = "using System; internal class Foo { } ";
        static void Main()
        {
            var instance = new Foo();
            var instanceSourceCode = instance.GetType().ToSourceCode();
            System.Diagnostics.Debug.Assert(instanceSourceCode == classSourceCode);
        }
    }
    
    static class TypeExtensions
    {
        public static string ToSourceCode(this Type source)
        {
            var assembly = AssemblyDefinition.ReadAssembly(Assembly.GetExecutingAssembly().Location);
            var type = assembly.MainModule.Types.FirstOrDefault(t => t.FullName == source.FullName);
            if (type == null) return string.Empty;
            var plainTextOutput = new PlainTextOutput();
            var decompiler = new CSharpLanguage();
            decompiler.DecompileType(type, plainTextOutput, new DecompilationOptions());
            return Regex.Replace(Regex.Replace(plainTextOutput.ToString(), @"\n|\r", " "), @"\s+", " ");
        }
    }
