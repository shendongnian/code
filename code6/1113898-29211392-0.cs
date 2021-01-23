    private void PopulateDeviceChoices(UserDeviceViewModel model)
    {
        model.DeviceChoices = db.Devices.Select(m => new SelectListItem
        {
            Text = m.Name,
            Value = m.Id
        };
    }
