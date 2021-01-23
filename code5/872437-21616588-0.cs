    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.CSharp;
    private static Func<double, double> CompileFunction(string expression)
    {
        StringBuilder sourceBuilder = new StringBuilder();
        sourceBuilder.AppendLine("using System;");
        sourceBuilder.AppendLine("using System.Linq.Expressions;");
        sourceBuilder.AppendLine("class ExpressionGenerator{");
        sourceBuilder.AppendLine("public static Func<double, double> Generate(){");
        sourceBuilder.AppendLine("return x => " + expression + ";");
        sourceBuilder.AppendLine("}}");
        Dictionary<string, string> providerOptions = new Dictionary<string, string>();
        providerOptions.Add("CompilerVersion", "v3.5");
        CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
        CompilerParameters parameters = new CompilerParameters(new[] { "System.Core.dll" });
        CompilerResults results = provider.CompileAssemblyFromSource(parameters, sourceBuilder.ToString());
        return (Func<double, double>)results.CompiledAssembly.GetType("ExpressionGenerator").GetMethod("Generate").Invoke(null, null);
    }
