    [StructLayout(LayoutKind.Explicit)]
        private struct AsnAny
        {
            [FieldOffset(0)]
            public readonly byte Type;
            [FieldOffset(4)]
            public readonly Int32 Number;
            [FieldOffset(4)]
            public readonly UInt32 Unsigned32;
            [FieldOffset(4)]
            public readonly UInt64 Counter64;
            [FieldOffset(4)]
            public readonly AsnOctetString String;
            [FieldOffset(4)]
            public readonly AsnOctetString Bits;
            [FieldOffset(4)]
            public readonly AsnObjectIdentifier Object;
            [FieldOffset(4)]
            public readonly AsnOctetString Sequence;
            [FieldOffset(4)]
            public readonly AsnOctetString IPAddress;
            [FieldOffset(4)]
            public readonly UInt32 Counter32;
            [FieldOffset(4)]
            public readonly UInt32 Gauge32;
            [FieldOffset(4)]
            public readonly UInt32 Ticks;
            [FieldOffset(4)]
            public readonly AsnOctetString Arbitrary;
        }
