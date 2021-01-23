            ...
            if (priority < DispatcherPriority.Loaded)
            {
                IntPtr capturedHandle = GetCapture();
                for (int i = 0; i < Application.Current.Windows.Count; i++)
                {
                    if (new WindowInteropHelper(
                                                Application.Current.Windows[i]
                                               ).Handle == capturedHandle)
                    {
                        Mouse.Capture(
                                      Application.Current.Windows[i],
                                      CaptureMode.Element
                                     );
                        Application.Current.Windows[i].ReleaseMouseCapture();
                        break;
                    }
                }
            }
            ...
