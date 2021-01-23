        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string sClassName, string sAppName);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(int hWnd, uint msg, int wParam, int lParam);
        private static void KillTabTip()
        {
            // Kill the previous process so the registry change will take effect.
            var processlist = Process.GetProcesses();
            foreach (var process in processlist.Where(process => process.ProcessName == "TabTip"))
            {
                process.Kill();
                break;
            }
        }
        public void ShowTouchKeyboard(bool isVisible, bool numericKeyboard)
        {
            if (isVisible)
            {
                const string keyName = "HKEY_CURRENT_USER\\Software\\Microsoft\\TabletTip\\1.7";
                var regValue = (int) Registry.GetValue(keyName, "KeyboardLayoutPreference", 0);
                var regShowNumericKeyboard = regValue == 1;
                // Note: Remove this if do not want to control docked state.
                var dockedRegValue = (int) Registry.GetValue(keyName, "EdgeTargetDockedState", 1);
                var restoreDockedState = dockedRegValue == 0;
                if (numericKeyboard && regShowNumericKeyboard == false)
                {
                    // Set the registry so it will show the number pad via the thumb keyboard.
                    Registry.SetValue(keyName, "KeyboardLayoutPreference", 1, RegistryValueKind.DWord);
                    // Kill the previous process so the registry change will take effect.
                    KillTabTip();
                }
                else if (numericKeyboard == false && regShowNumericKeyboard)
                {
                    // Set the registry so it will NOT show the number pad via the thumb keyboard.
                    Registry.SetValue(keyName, "KeyboardLayoutPreference", 0, RegistryValueKind.DWord);
                    // Kill the previous process so the registry change will take effect.
                    KillTabTip();
                }
                // Note: Remove this if do not want to control docked state.
                if (restoreDockedState)
                {
                    // Set the registry so it will show as docked at the bottom rather than floating.
                    Registry.SetValue(keyName, "EdgeTargetDockedState", 1, RegistryValueKind.DWord);
                    // Kill the previous process so the registry change will take effect.
                    KillTabTip();
                }
                Process.Start("c:\\Program Files\\Common Files\\Microsoft Shared\\ink\\TabTip.exe");
            }
            else
            {
                var win8Version = new Version(6, 2, 9200, 0);
                if (Environment.OSVersion.Version >= win8Version)
                {
                    const uint wmSyscommand = 274;
                    const uint scClose = 61536;
                    var keyboardWnd = FindWindow("IPTip_Main_Window", null);
                    PostMessage(keyboardWnd.ToInt32(), wmSyscommand, (int)scClose, 0);
                }
            }
        }
