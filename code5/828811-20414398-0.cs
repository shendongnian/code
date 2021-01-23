    class DynamicMethodTest {
        private MethodInfo _methodToCall;
        private object _obj;
        public void PerformInjection(string newBody) {
            using (var codeProvider =
           new Microsoft.CSharp.CSharpCodeProvider()) {
                var res = codeProvider.CompileAssemblyFromSource(
                    new System.CodeDom.Compiler.CompilerParameters() {
                        GenerateInMemory = true
                    },
                    "public class StubClass { public bool Evaluate(int number) { " + newBody + " }}"
                );
                var type = res.CompiledAssembly.GetType("StubClass");
                _obj = Activator.CreateInstance(type);
                _methodToCall = _obj.GetType().GetMethod("Evaluate");
            }
        }
        public bool Evaluate(int number) {
            if (_methodToCall != null)
                return (bool)_methodToCall.Invoke(_obj, new object[] { number });
            return false;
        }
    }
