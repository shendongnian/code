                title = process.MainWindowTitle;
                if (title == @"Registry Editor" && process.MainWindowHandle != IntPtr.Zero)
                {
                    SetForegroundWindow(process.MainWindowHandle);
                    Thread.Sleep(2000);
                    SendKeys.SendWait("%+F+E");
                    Thread.Sleep(500);
                    SendKeys.SendWait("%+A");
                    Thread.Sleep(500);
                    SendKeys.SendWait("%+S");
                    Thread.Sleep(500);
                    SendKeys.SendWait("TEST");
                    Thread.Sleep(500);
                    SendKeys.SendWait("%+S");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("%+{TAB}");
                    break;
                }
            }`
