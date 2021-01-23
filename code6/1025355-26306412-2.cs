    class TestClass {
        public static TimeSpan HandWrittenMethod(int i) {
            return TimeSpan.FromSeconds(i);
        }
   
        public void CreateDynamic() {
            // Other codes...
            var methodInfo = typeof(TestClass).GetMethod("HandWrittenMethod");
            il.Emit(OpCodes.Ldc_I4_S, 10);
            il.Emit(OpCodes.Callvirt, methodInfo);
            il.Emit(OpCodes.Ret);
            // Other codes...
        }
    }
