    try
    {
        gCHandle = GCHandle.Alloc(hGlobalUni, GCHandleType.Pinned);
        if (!UnsafeNativeMethods.StartService(serviceHandle, (int)args.Length, gCHandle.AddrOfPinnedObject()))
        {
            Exception exception = ServiceController.CreateSafeWin32Exception();
            object[] serviceName = new object[] { this.ServiceName, this.MachineName };
            throw new InvalidOperationException(Res.GetString("CannotStart", serviceName), exception);
        }
    }
