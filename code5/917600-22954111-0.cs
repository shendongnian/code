     // Adjusts the CreateParams to reflect the window bounds and start position.
     private void FillInCreateParamsStartPosition(CreateParams cp) { 
        switch ((FormStartPosition)formState[FormStateStartPos]) {
            case FormStartPosition.WindowsDefaultBounds: 
                cp.Width = NativeMethods.CW_USEDEFAULT;
                cp.Height = NativeMethods.CW_USEDEFAULT; 
                ...
            case FormStartPosition.WindowsDefaultLocation: 
            case FormStartPosition.CenterParent:
                ...
                cp.X = NativeMethods.CW_USEDEFAULT;
                cp.Y = NativeMethods.CW_USEDEFAULT;
                break;
            case FormStartPosition.CenterScreen: 
                if (IsMdiChild) {
                    ...
                    cp.X = Math.Max(clientRect.X,clientRect.X + (clientRect.Width - cp.Width)/2); 
                    cp.Y = Math.Max(clientRect.Y,clientRect.Y + (clientRect.Height - cp.Height)/2);
                }
                else {
                    ...
                    if (WindowState != FormWindowState.Maximized) { 
                        cp.X = Math.Max(screenRect.X,screenRect.X + (screenRect.Width - cp.Width)/2); 
                        cp.Y = Math.Max(screenRect.Y,screenRect.Y + (screenRect.Height - cp.Height)/2);
                    } 
                }
                break;
        }
    }
