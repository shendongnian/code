    static readonly s_semaphore = new SemaphoreSlim(1);
    public static async Task<IList<ushort>> ReadDataItem(DriverType driverType, string ip, DataItemAddress address, Action<IList<ushort>> callback)
    {
        using (var driver = RetrieveDriver(driverType))
        {
            if (!driver.Initialized)
            {
                //NOTE: Make sure connection is set up to correct PLC
            }
            // you can use different semaphores,
            // depending on the type of the driver
            await s_semaphore.WaitAsync();
            try
            {
                return await ask.Factory.StartNew(() => driver.ReadDataItem(address));
            }
            finally
            {
                s_semaphore.Release();
            }
        }
    }
