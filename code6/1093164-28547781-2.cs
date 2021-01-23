    private static bool Fullscreen
    {
        get
        {
            return _window.IsFullscreen;
        }
        set
        {
            _window.IsFullscreen = value;
            // Do not resize multiple times by preventing the resized event
            _window.UserResized -= _window_UserResized;
            _swapChain.SetFullscreenState(_window.IsFullscreen, null);
            // Resize the window when returning to windowed mode to fit the most recent resolution
            if (!_window.IsFullscreen)
            {
                // Fix the corrupt window style missing WS_VISIBLE in apps which started in fullscreen
                int style = GetWindowLong(_window.Handle, GWL_STYLE).ToInt32();
                style |= WS_VISIBLE;
                SetWindowLong(_window.Handle, GWL_STYLE, style);
                // Still need to set an icon here, as the SharpDX default one isn't set
                _window.ClientSize = _resolution;
            }
            // Allow new resize events
            _window.UserResized += _window_UserResized;
        }
    }
