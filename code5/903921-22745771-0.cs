    [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
    private static unsafe extern void MoveMemory(IntPtr dest, IntPtr src, int size);
    private void OnAudioAvailable(object sender, AsioAudioAvailableEventArgs e)
        {
            for (int i = 0; i < e.InputBuffers.Length; i++)
            {
                MoveMemory(e.OutputBuffers[i], e.InputBuffers[i], e.SamplesPerBuffer * e.InputBuffers.Length);
            }
            e.WrittenToOutputBuffers = true;
        }
