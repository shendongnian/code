      public IList<DeviceBO> GetAllDevices(int page, out int count)
      {
            count = DataProvider.Devices.GetAllDevicesCount();
            return DataProvider.Devices.GetAllDevices(page, BusinessConstants.GRID_PAGE_SIZE);
      }
