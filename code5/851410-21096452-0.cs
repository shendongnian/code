    var propertySet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject,
        AppointmentSchema.Start, AppointmentSchema.End, AppointmentSchema.Location,
        AppointmentSchema.RequiredAttendees, AppointmentSchema.OptionalAttendees);
    var results = service.FindItems(id, searchFilter, view); // first call
    service.LoadPropertiesForItems(results, propertySet); // second call
