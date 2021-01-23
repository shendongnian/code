        public struct MyX
        {
            public int IntValue;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U1)]
            public byte[] Array;
            MyX(int i, int b)
            {
                IntValue = b;
                Array = new byte[3];
            }
            public MyX ToStruct(byte []ar)
            {
                byte[] data = ar;//= { 1, 0, 0, 0, 9, 8, 7 }; // IntValue = 1, Array = {9,8,7}
                IntPtr ptPoit = Marshal.AllocHGlobal(data.Length);
                Marshal.Copy(data, 0, ptPoit, data.Length);
                MyX x = (MyX)Marshal.PtrToStructure(ptPoit, typeof(MyX));
                Marshal.FreeHGlobal(ptPoit);
                return x;
            }
            public byte[] ToBytes()
            {
                Byte[] bytes = new Byte[Marshal.SizeOf(typeof(MyX))];
                GCHandle pinStructure = GCHandle.Alloc(this, GCHandleType.Pinned);
                try
                {
                    Marshal.Copy(pinStructure.AddrOfPinnedObject(), bytes, 0, bytes.Length);
                    return bytes;
                }
                finally
                {
                    pinStructure.Free();
                }
            }
        }
        void function()
        {
            byte[] data = { 1, 0, 0, 0, 9, 8, 7 }; // IntValue = 1, Array = {9,8,7}
            IntPtr ptPoit = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, ptPoit, data.Length);
          
            var x = (MyX)Marshal.PtrToStructure(ptPoit, typeof(MyX));
            Marshal.FreeHGlobal(ptPoit);
            var MYstruc = x.ToStruct(data);
            Console.WriteLine("x.IntValue = {0}", x.IntValue);
            Console.WriteLine("x.Array = ({0}, {1}, {2})", x.Array[0], x.Array[1], x.Array[2]);
        }
