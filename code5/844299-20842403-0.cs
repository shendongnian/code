        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BlockInput(bool fBlockIt);
        public static void Block(int mill)
        {
            if (!BlockInput(true)) {
                throw new System.ComponentModel.Win32Exception();
            }
            // etc..
        }
