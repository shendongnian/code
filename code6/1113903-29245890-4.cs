    model.DeviceChoices = db.Devices.Select(m => new SelectListItem
    {
        Text = m.Name,
        Value = m.DeviceID.ToString()
    });
