    public class ProcessManager
    {
        private IntPtr _buffer = IntPtr.Zero;
        private IntPtr _hwnd = IntPtr.Zero;
        private string _filenameMarker;
        public void StartAssiciatedProcessAndBringItToFront(string fileName, string fileNameMarker)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException();
            _filenameMarker = fileNameMarker;
            try
            {
                Process.Start(fileName);
                if (!string.IsNullOrEmpty(_filenameMarker))
                {
                    _buffer = IntPtr.Zero;
                    _hwnd = IntPtr.Zero;
                    _buffer = Marshal.AllocHGlobal(512);
                    NativeHelpers.EnumWindows(new NativeHelpers.EnumWindowsProc(searcher), IntPtr.Zero);
                    if (_hwnd != IntPtr.Zero)
                    {
                        BringToFront(_hwnd);
                    }
                }
            }
            finally
            {
                if (_buffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(_buffer);
                    _buffer = IntPtr.Zero;
                }
                _hwnd = IntPtr.Zero;
                _filenameMarker = null;
            }
        }
        private int searcher(IntPtr hWnd, IntPtr lParam)
        {
            int result;
            int ok = NativeHelpers.SendMessageTimeout(hWnd,
                                                      NativeHelpers.WM_GETTEXT,
                                                      new IntPtr(250),
                                                      _buffer,
                                                      NativeHelpers.SMTO_BLOCK | NativeHelpers.SMTO_ABORTIFHUNG,
                                                      100,
                                                      out result);
            if (ok == 0)
                return 1; // ignore this and continue
            if (result > 0)
            {
                string windowName = Marshal.PtrToStringAuto(_buffer);
                if (windowName.Contains(_filenameMarker))
                {
                    _hwnd = hWnd;
                    return 0; // stop search
                }
            }
            return 1; // continue
        }
        private static void BringToFront(IntPtr hwnd)
        {
            if (NativeHelpers.IsIconic(hwnd) != 0)
                NativeHelpers.ShowWindowAsync(hwnd, NativeHelpers.SW_RESTORE);
            NativeHelpers.SetForegroundWindow(hwnd);
        }
        public void StartAssiciatedProcessAndBringItToFront(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException();
            try
            {
                var p = Process.Start(fileName);
                p.WaitForInputIdle(5 * 1000);
                _hwnd = p.MainWindowHandle;
                if (_hwnd != IntPtr.Zero)
                {
                    BringToFront(_hwnd);
                }
            }
            catch
            {
            }
        }
    }
