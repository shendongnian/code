    namespace NAudio.CoreAudioApi.Interfaces
    {
        /// <summary>
        /// n.b. WORK IN PROGRESS - this code will probably do nothing but crash at the moment
        /// Defined in AudioClient.h
        /// </summary>
        [Guid("1CB9AD4C-DBFA-4c32-B178-C2F568A703B2"), 
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioClient
        {
            [PreserveSig]
            int Initialize(AudioClientShareMode shareMode,
                AudioClientStreamFlags StreamFlags,
                long hnsBufferDuration, // REFERENCE_TIME
                long hnsPeriodicity, // REFERENCE_TIME
                [In] WaveFormat pFormat,
                [In] ref Guid AudioSessionGuid);
