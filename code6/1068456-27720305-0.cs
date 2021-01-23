    using System;
    using RGiesecke.DllExport;
    namespace JnaTestLibrary
    {
      public class JnaTest
      {
        [DllExport]
        public unsafe static byte* returnT1()
        {
            byte[] t1 = {1,2,3,4,5};
            fixed (byte* p1 = t1)
            {
              return p1;
            }
        }
      }
    }
