    AppointmentItem newAppointment = Globals.ThisAddIn.Application.CreateItem(OlItemType.olAppointmentItem);
    newAppointment.MeetingStatus = OlMeetingStatus.olMeeting;
    
    Recipients recipients = newAppointment.Recipients;
    Recipient readyByRecipient = null;
    readyByRecipient = recipients.Add(emailAddress);
    readyByRecipient.Type = (int)OlMeetingRecipientType.olRequired;
    recipients.ResolveAll();
    newAppointment.Display();
    
    Inspector inspector = newAppointment.GetInspector;
    inspector.CommandBars.ExecuteMso("ShowSchedulingPage");
    
    Marshal.ReleaseComObject(readyByRecipient);
    Marshal.ReleaseComObject(recipients);
    Marshal.ReleaseComObject(newAppointment);
    Marshal.ReleaseComObject(inspector);
