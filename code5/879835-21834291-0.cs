            //Get the text of a control with its handle
            private string GetText(IntPtr handle)
            {
                int maxLength = 100;
                IntPtr buffer = Marshal.AllocHGlobal((maxLength + 1) * 2);
                SendMessageW(handle, WM_GETTEXT, maxLength, buffer);
                int selectionStart = -1;
                int selectionEnd = -1;
                SendMessage(handle, EM_GETSEL, out selectionStart, out selectionEnd);
                string w = Marshal.PtrToStringUni(buffer);
                Marshal.FreeHGlobal(buffer);
                if (selectionStart > 0 && selectionEnd >0)
                {
                    w = w.Substring(selectionStart, selectionEnd - selectionStart); //We need to send the length
                }
                return w;
            }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, out int wParam, out int lParam);
        public const uint EM_GETSEL = 0xB0;
