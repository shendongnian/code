    public static class MarshalExtender
    {
        public static IntPtr CopyToCoTaskMem(this byte[] array)
        {
            var ptr = AllocArrayCoTaskMem(array);
            Marshal.Copy(array, 0, ptr, array.Length);
            return ptr;
        }
        // Copy the above method and replace types as needed (int, double, etc).
        // Helper method for allocating bytes with generic arrays.
        static IntPtr AllocArrayCoTaskMem<T>(T[] array)
        {
            var type = typeof(T);
            var size = Marshal.SizeOf(type) * array.Length;
            return Marshal.AllocCoTaskMem(size);
        }
    }
