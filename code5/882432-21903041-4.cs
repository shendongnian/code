    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddAttendeeManual(CreateAppointmentSelectPersons manualEmail)
    {
       bool result = _attendeeRepository.CheckIfAttendeeExists(manualEmail.SelectedManualEmail.AppointmentId, manualEmail.SelectedManualEmail.Email);
        if(!result)
        {
            _attendeeRepository.AddManualAttendee(manualEmail.SelectedManualEmail.AppointmentId,
            manualEmail.SelectedManualEmail.Email);
        }
        return Json(new { AttendeeExists = result, ErrorMessage = "Attendee already exists" });
    }
