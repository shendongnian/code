    public static void MuteApplication()
    {
      int NewVolume = 0;
      uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
      waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
    }
