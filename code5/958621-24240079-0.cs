    [HttpPost]
        public ActionResult ConfirmAppointment(AppointmentViewModel avm)
        {
            context = new SchedulingDataClassesDataContext();
            if (ModelState.IsValid)
            {
                //logical code
            }
            ViewBag.Medecins = new SelectList(context.DBMedecins, "MedecinId", "FullName");
            return View(avm);
        }
