    private static void Main(string[] args)
    {
        _window = new RenderForm();
        _window.KeyDown += _window_KeyDown;
        _window.IsFullscreen = true;
        _window.Show(); // Do not forget this or window styles may break
        // Set default resolution.
        _resolution = new Size(800, 600);
        // Describe the swap chain buffer mode.
        ModeDescription bufferDescription = new ModeDescription()
        {
            Width = _resolution.Width,
            Height = _resolution.Height,
            RefreshRate = new Rational(60, 1),
            Format = Format.R8G8B8A8_UNorm
        };
        // Describe the swap chain.
        SwapChainDescription swapChainDescription = new SwapChainDescription()
        {
            ModeDescription = bufferDescription,
            SampleDescription = new SampleDescription(1, 0),
            Usage = Usage.RenderTargetOutput,
            BufferCount = 1,
            OutputHandle = _window.Handle,
            IsWindowed = !_fullscreen,
            Flags = SwapChainFlags.AllowModeSwitch // Allows other fullscreen resolutions than native one.
        };
        // Create the device with the swap chain.
        SharpDX.Direct3D11.Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None,
            swapChainDescription, out _device, out _swapChain);
        _deviceContext = _device.ImmediateContext;
        // Set the resolution to run the code which resizes the internal buffers.
        Resolution = _resolution;
        RenderLoop.Run(_window, Loop);
    }
