    ...
    string _PreviousMeetingId = string.Empty; // class-level variable
    ...
    private void appointments_Add(object item)
        {
            // An appointment has been added. Read the title and send an email based on a condition.
            Outlook.AppointmentItem meetingItem = item as Outlook.AppointmentItem;
            if (meetingItem.Subject.Contains("Service Call") && _PreviousMeetingId != meetingItem.GlobalAppointmentID)
            {
                // Let's send ourselves an email.
                string emailTo = string.Format("{0}@concurrency.com", Environment.UserName);
                string subject = meetingItem.Subject;
                string body = meetingItem.Body;
                string startDate = meetingItem.Start.ToString();
                string endDate = meetingItem.End.ToString();
                SendEmailAlert(emailTo, subject, body, startDate, endDate);
                // Save the ID of the meeting so we can check it later (above).
                _PreviousMeetingId = meetingItem.GlobalAppointmentID;
            }
        }
