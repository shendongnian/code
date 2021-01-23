    class TestClass {
        private static TimeSpan CompilerGeneratedMethod(int i) {
            return TimeSpan.FromSeconds(i);
        }
   
        public void CreateDynamic() {
            // Other codes...
            var methodInfo = typeof(TestClass).GetMethod("CompilerGeneratedMethod", BindingFlags.Static | BindingFlags.NonPublic);
            il.Emit(OpCodes.Ldc_I4_S, 10);
            il.Emit(OpCodes.Callvirt, methodInfo);
            il.Emit(OpCodes.Ret);
            // Other codes...
        }
    }
