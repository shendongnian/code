                CodeDomProvider provider = CSharpCodeProvider.CreateProvider("C#");
                CompilerParameters options = new CompilerParameters();
                options.GenerateExecutable = false;
                options.GenerateInMemory = true;
                // create code
                string source = "using System;namespace Expression{public static class Expression{public static void Test() {\n";
                source += expression; // your expression
                source +=";}}}";
                // compile
                var result = provider.CompileAssemblyFromSource(options, source);
                if (result.Errors.HasErrors)
                    foreach (CompilerError error in result.Errors)
                        ; // use error.Column and .Row to get where error was, use .ErrorText to get actuall message, to example "Unknown variable aaa"
