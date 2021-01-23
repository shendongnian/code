        /// <summary>
        /// Native Win32 API setFocus method.
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SetFocus(IntPtr hWnd);        
        /// <summary>
        /// Win32 API call to set focus (workaround for WindowsFormsHost permanently stealing focus).
        /// </summary>
        public void Win32SetFocus()
        {
            var wih = new WindowInteropHelper(this); // "this" being class that inherits from WPF Window
            IntPtr windowHandle = wih.Handle;
            SetFocus(windowHandle);
        }
