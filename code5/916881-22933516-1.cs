    unitOfWork.deviceInstanceRepository.Get()
              .GroupBy(w => new
              {
                  DeviceId = w.DeviceId,
                  Device = w.Device.Name,
                  Manufacturer = w.Device.Manufacturer,
              })
              .Select(s => new
              {
                  DeviceId = s.Key.DeviceId,
                  Name = s.Key.Device,
                  Manufacturer = s.Key.Manufacturer.Name,
                  Quantity = s.Sum(x => x.Quantity)
              })
