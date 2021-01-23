            var prov = CodeDomProvider.CreateProvider("C#");
            var gen = prov.CreateGenerator();
            using (var writer = new System.IO.StreamWriter("c:\\temp\\test.cs")) {
                gen.GenerateCodeFromCompileUnit(ccUnit, writer, new CodeGeneratorOptions());
            }
            
            var result = prov.CompileAssemblyFromDom(parameters, ccUnit);
