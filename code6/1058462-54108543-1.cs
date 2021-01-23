    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal unsafe struct Joint
    {
        [MarshalAs(UnmanagedType.I4)]
        public int id;
        [MarshalAs(UnmanagedType.R4)]
        public float posX;
        [MarshalAs(UnmanagedType.R4)]
        public float posY;
        [MarshalAs(UnmanagedType.R4)]
        public float posZ;
    }
    [DllImport("TheDLL")]
    static extern void GetJointArray(Joint[] jointArray, out int length);
    int itemsLength = 0;
    Joint[] result = new Joint[2]; // Of course you need an additional dll function call to get the size of the array before
    GetJointArray( result, out itemsLength);
    Debug.Log("ITEMS LENGTH:" + itemsLength);
    Debug.Log("JOINT1 ID:" + result[0].id);
