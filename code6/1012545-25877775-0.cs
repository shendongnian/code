            var compiler = new CSharpCodeProvider();
            string source = "using DLLBeingTested; \r\n" +
                            "public class DoIt {\r\n" +
                            "public void DoSomething() {\r\n" +
                            "var x =  new Logger(\"abc.txt\");\r\n" +
                            "}}" +
                            "";
            var loc = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var cp = new CompilerParameters(new[] { Path.Combine(loc, "DLLBeingTested.dll") });
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            var assm = compiler.CompileAssemblyFromSource(cp, source);
            bool foundExpectedError = false;
            foreach (var err in assm.Errors)
            {
                if (err.ToString().Contains("CS0143"))
                {
                    foundExpectedError = true;
                }
            }
            Assert.IsTrue(foundExpectedError);
