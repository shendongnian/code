    try
    {
        ((AppointmentItem)calendarFolder.Items.Add(OlItemType.olAppointmentItem)).Delete();
        
        // Do whatever you need with this folder.
    }
    catch
    {
        // This probably means the folder is not writeable.
    }
