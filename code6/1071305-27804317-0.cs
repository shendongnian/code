        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
        public static bool isTouchEnabled()
        {
            int MAXTOUCHES_INDEX = 0x95;
            int maxTouches = GetSystemMetrics(MAXTOUCHES_INDEX);
            return maxTouches > 0;
        }
