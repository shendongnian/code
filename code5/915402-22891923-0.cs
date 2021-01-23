     [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(
            IntPtr hInternet,
            int dwOption,
            IntPtr lpBuffer,
            int lpdwBufferLength);
        public struct Struct_INTERNET_PROXY_INFO
        {
            public int dwAccessType;
            public IntPtr proxy;
            public IntPtr proxyBypass;
        }
        private void UseProxy(string strProxy)
        {
            const int INTERNET_OPTION_PROXY = 38;
            const int INTERNET_OPEN_TYPE_PROXY = 3;
            Struct_INTERNET_PROXY_INFO struct_IPI = default(Struct_INTERNET_PROXY_INFO);
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
            struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy);
            struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local");
            IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));
            Marshal.StructureToPtr(struct_IPI, intptrStruct, true);
            bool iReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, System.Runtime.InteropServices.Marshal.SizeOf(struct_IPI));
        }
        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            Label4.Text = (TextBox1.Text + ":" + TextBox2.Text);
        }
        private void Button2_Click(System.Object sender, System.EventArgs e)
        {
            UseProxy(Label4.Text);
            WebBrowser1.Navigate(TextBox3.Text);
        }
       
