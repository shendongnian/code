    async void OnSuspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
    {
        var Deferral = e.SuspendingOperation.GetDeferral();
        using (var Device = new SharpDX.Direct3D11.Device(SharpDX.Direct3D.DriverType.Hardware, SharpDX.Direct3D11.DeviceCreationFlags.BgraSupport, new[] { SharpDX.Direct3D.FeatureLevel.Level_11_1, SharpDX.Direct3D.FeatureLevel.Level_11_0 }))
        using (var Direct3DDevice = Device.QueryInterface<SharpDX.Direct3D11.Device1>())
        using (var DxgiDevice3 = Direct3DDevice.QueryInterface<SharpDX.DXGI.Device3>())
            DxgiDevice3.Trim();
        Deferral.Complete();
    }
