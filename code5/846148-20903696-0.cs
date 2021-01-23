    using System;
    using System.Reflection.Emit;
    using System.Text;
    
    class ILLabelDemo {
        public static DynamicMethod GetStringForEncoding(Encoding encoding) {
            var getstringMethod = encoding.GetType().GetMethod("GetString", 
                new Type[] { typeof(byte[]) });    
            var getStringCreator = new DynamicMethod("foo", typeof(string), 
                new Type[] { typeof(byte[]), encoding.GetType() }, typeof(void));
            ILGenerator gen = getStringCreator.GetILGenerator();
    
            gen.Emit(OpCodes.Ldarg_1);  // this is the instance for callvirt
            gen.Emit(OpCodes.Ldarg_0);        
            gen.Emit(OpCodes.Callvirt, getstringMethod);
            gen.Emit(OpCodes.Box, typeof(string));
            gen.Emit(OpCodes.Ret);
    
            return getStringCreator;
        }
    
        public static void Main() {
            var utf8 = Encoding.GetEncoding("utf-8");
            var method = GetStringForEncoding(utf8);
            Console.WriteLine(method.Invoke(null, new object[2] { 
                new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20,
                             0x32, 0x30, 0x31, 0x34, 0x21 }, 
                utf8 } ));
        }
    }
    // Output:
    Hello 2014!
