        __declspec(dllexport) BOOL __stdcall GetField(MyStruct * s, int & result)
        {
            result = 0;
            try
            {
                result = s->GetField();
            }
            catch(...)
            {
                return FALSE;
            }
            return TRUE;
        }
    and:
        protected class Native
        {
            [DllImport("MyDll.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetField(IntPtr res, out int result);
        }
    and:
        // Wrapper
        int GetField()
        {
            int result;
            if !(Native.GetField(res, out result))
                throw new InvalidOperationException("Resource does not support field!");
        }
