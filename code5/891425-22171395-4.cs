     public double Calculate(string script)
     {
       ScriptEngine engine = Python.CreateEngine();
       ScriptSource source = engine.CreateScriptSourceFromString("import math" + Environment.NewLine + script, Microsoft.Scripting.SourceCodeKind.AutoDetect);
       return source.Execute<double>();
     }
