    namespace System.Threading
    {
        public static class Monitor 
        {
            // other methods omitted
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            private static extern void ObjPulseAll(Object obj);
            public static void PulseAll(Object obj)
            {
                if (obj==null) {
                    throw new ArgumentNullException("obj");
                }
                ObjPulseAll(obj);
            } 
        }
    }
