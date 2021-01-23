    private IntPtr WinProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
            switch (msg)
            {
                case Win32.WmChangecbchain:
                    if (wParam == this.hWndNextViewer)
                        this.hWndNextViewer = lParam; //clipboard viewer chain changed, need to fix it.
                    else if (this.hWndNextViewer != IntPtr.Zero)
                        Win32.SendMessage(this.hWndNextViewer, msg, wParam, lParam); //pass the message to the next viewer.
                    break;
                case Win32.WmDrawclipboard:
                    Win32.SendMessage(this.hWndNextViewer, msg, wParam, lParam); //pass the message to the next viewer //clipboard content changed
                    if (Clipboard.ContainsText() && !string.IsNullOrEmpty(Clipboard.GetText().Trim()))
                    {
                        Application.Current.Dispatcher.Invoke(
                            DispatcherPriority.Background,
                            (Action)
                                delegate
                                {
                                    var currentText = Clipboard.GetText().RemoveSpecialCharacters();
                                    if (!string.IsNullOrEmpty(currentText))
                                    {
                                        //In this section, we are doing something, because TEXT IS CAPTURED.
                                        Task.Run(
                                            async () =>
                                            {
                                                if (this.mainWindow.CancellationTokenSource.Token.IsCancellationRequested)
                                                    return;
                                                await
                                                    this.WhenClipboardContainsTextEventHandler.InvokeSafelyAsync(this,
                                                        new WhenClipboardContainsTextEventArgs { CurrentString = currentText });
                                            });
                                    }
                                });
                    }
                    break;
            }
            return IntPtr.Zero;
    }
