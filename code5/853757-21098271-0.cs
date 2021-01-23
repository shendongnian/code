    fixed(byte* ptrOutput= &outputBufferBuffer[0])
    {
        MoveMemory(ptrOutput, ptrInput, 4);
    }
    [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
    private static unsafe extern void MoveMemory(void* dest, void* src, int size);
