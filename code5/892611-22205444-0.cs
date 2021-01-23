        [StructLayout(LayoutKind.Sequential)]
        public struct TEST_STRUCT {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public UInt16[] check;
        }
