    [StructLayout(LayoutKind.Explicit)]
    public struct Test
    {
        [FieldOffset(3)]
        public readonly byte pop;
        [FieldOffset(2)]
        public readonly byte svp;
        [FieldOffset(1)]
        public readonly byte uhdp;
        [FieldOffset(0)]
        public readonly byte mhdp;
        
        [FieldOffset(0)]
        private int value;
        
        public static Test FromInt32(int value)
        {
            var test = new Test();
            test.value = value;
            return test;
        }
    }
