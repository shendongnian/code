     public JsonResult GetAppointments(double start, double end)
        {
            var apptListForDate = CalendarUtility.LoadAllAppointmentsInDateRange(start, end);
            var eventList = from e in apptListForDate
                            select new
                            {
                                id = e.ID,
                                studentid = e.StudentId,
                                student = e.Student,
                                title = e.Title,
                                start = e.StartDateString,
                                end = e.EndDateString,
                                instructor  =e.Instructor,
                                notes = e.Notes,
                                color = e.StatusColor,
                                className = e.ClassName,
                                someKey = e.SomeImportantKeyId,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
