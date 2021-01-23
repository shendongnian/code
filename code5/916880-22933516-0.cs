    unitOfWork.deviceInstanceRepository.Get()
              .GroupBy(w => new
              {
                  w.DeviceId,
                  w.Device.Name,
                  w.Device.Manufacturer,
              })
              .Select(s => new
              {
                  DeviceId = s.Key.DeviceId,
                  Name = s.Key.Device.Name,
                  Manufacturer = s.Key.Manufacturer.Name,
                  Quantity = s.Sum(x => x.Quantity)
              })
