     [DllExport("ExpTest", CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static string ExpTest([MarshalAs(UnmanagedType.LPWStr)] string sText, out int length)
        {
            MessageBox.Show(sText);
            length=sText.Length;
            return sText;
        }
