    public ActionResult Stock()
    {
        var devices = db.Device.Where(s => s.Status.ToUpper().Contains("Stock"))
              .GroupBy(d => d.DeviceTypeName)
              .Select(d => new DeviceGroupViewModel
              {
                  Type = d.Key,
                  Count = d.Count()
              }).ToList();
        
        return View(devices);
    }
