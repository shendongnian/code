        [StructLayout(LayoutKind.Explicit)]
        public struct TypeAorB
        {
            [FieldOffset(0)]
            public TypeA aa;
            [FieldOffset(8)]
            public TypeB bb;
            [FieldOffset(16)]
            public TypeB bb;
        }
