    public static unsafe void Copy(IntPtr ptrSource, ushort[] dest, uint elements) {
      fixed(ushort* ptrDest = &dest[0]) {
         CopyMemory((IntPtr)ptrDest, ptrSource, elements * 2);    // 2 bytes per element
      }
    }
    public static unsafe void Copy(ushort[] source, Intptr ptrDest, uint elements) {
      fixed(ushort* ptrSource = &source[0]) {
         CopyMemory(ptrDest, (Intptr)ptrSource, elements * 2);    // 2 bytes per element
      }
    }
    [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
    static extern void CopyMemory(IntPtr Destination, IntPtr Source, uint Length);
