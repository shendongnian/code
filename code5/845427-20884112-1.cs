    namespace test
    {
            [StructLayout(LayoutKind.Explicit, Size = 128)]
            internal unsafe struct Frame
            {
                [FieldOffset(0)]
                public fixed byte Bytes[128];
    
                [FieldOffset(0)]
                public long Low;
    
                [FieldOffset(128 - sizeof(long))]
                public long High;
                
            }
    
        internal class NewClass
        {
            public Frame FixedBytesArray;
        }
    
        internal class Program
        {
            static void Main(string[] args)
            {
                unsafe
                {
                    NewClass NewType = new NewClass();
                    NewType.FixedBytesArray.High = 12345;
                    NewType.FixedBytesArray.Low = 6789;
                    // ERROR: Error 15  You cannot use the fixed statement to take the address of an already fixed expression
                    fixed (byte* ptr = NewType.FixedBytesArray.Bytes)
                    {
                        byte[] bytes = new byte[128];
                        int index = 0;
                        for (byte* counter = ptr; *counter != 0; counter++)
                        {
                            bytes[index++] = *counter;
                        }
    
    
                        // ERROR
                        Console.Write(System.Text.Encoding.ASCII.GetString(bytes, 0, 128));
                        //frame.Low = 1234;
                        //Console.Write(System.Text.Encoding.ASCII.GetString(frame.Low));
                        //frame.High = 5678;
                        //Console.Write(System.Text.Encoding.ASCII.GetString(frame.Bytes));
                    }
                }
    
            }
        }
    }
