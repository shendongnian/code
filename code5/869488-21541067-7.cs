    using System;
    using System.Runtime.InteropServices;
    namespace InteropTesting
    {
        public static class Invoker
        {
            private delegate void TestCallbackDelegate();
            public static int InvokeCallback( string param )
            {
                //C# has a built-in means of turning byte arrays into integers
                //so we'll use BitConverter instead of using the bitwise operators.
                char[] chars = param.ToCharArray();
                int ptr = BitConverter.ToInt32( Array.ConvertAll( chars, c => (byte)c ), 0 );
                var test_callback = (TestCallbackDelegate)Marshal.GetDelegateForFunctionPointer( new IntPtr( ptr ), typeof( TestCallbackDelegate ) );
                test_callback();
                return 0;
            }
        }
    }
