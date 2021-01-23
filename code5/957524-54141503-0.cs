       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
            [FieldOffset(4)]
            private char[] zSlotName;
            public char[] _zSlotName
            {
                get { return zSlotName; }
                set {
                    zSlotName = new char[9];
                    for (int i = 0; i < zSlotName.Length; i++)
                    {
                        if (value.Length > i)
                            zSlotName[i] = value[i];
                        else
                            zSlotName[i] = ' ';
                    }
                }
            }
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(13)]
            private int nThreadId;
            public int _nThreadId
            {
                get { return nThreadId; }
                set { nThreadId = value; }
            }
