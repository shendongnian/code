    public class Wav
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern bool PlaySound(String lpszName, IntPtr hModule, Int32 dwFlags);
    
        public static bool Play(string wavFileName)
        {
            try
            {
                return PlaySound(wavFileName, IntPtr.Zero, 0);
            }
            catch
            {
                return false;
            }
        }
    }
