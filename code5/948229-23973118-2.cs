    ContactItem contact;
    PropertyAccessor pa = contact.PropertyAccessor;
    Byte[] ba = pa.GetProperty("http://schemas.microsoft.com/mapi/id/{00062004-0000-0000-C000-000000000046}/804D0102");
    string birthdayAppointmentItemID = BitConverter.ToString(ba).Replace("-", string.Empty);
    
    NameSpace ns = outlookObject.GetNamespace("MAPI");
    AppointmentItem birthdayAppointmentItem = ns.GetItemFromID(birthdayAppointmentItemID);
