    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddAttendeeManual(CreateAppointmentSelectPersons manualEmail)
    {
        bool result = _attendeeRepository.CheckIfAttendeeExists(manualEmail.SelectedManualEmail.AppointmentId, manualEmail.SelectedManualEmail.Email);
        if(!result)
        {
            _attendeeRepository.AddManualAttendee(manualEmail.SelectedManualEmail.AppointmentId,
            manualEmail.SelectedManualEmail.Email);
            //this doesn't necessarily guarantee the onError won't get called
            //there are other reasons your ajax request could fail
        }
        else
        {               
            //throw an exception
            throw new Exception("Ajax Call Failed!");
        }
    }
