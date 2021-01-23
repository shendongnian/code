            ...
            if (priority < DispatcherPriority.Loaded)
            {
                IntPtr capturingHandle = GetCapture();
                for (int i = 0; i < Application.Current.Windows.Count; i++)
                {
                    if (new WindowInteropHelper(
                                                Application.Current.Windows[i]
                                               ).Handle == capturingHandle)
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
