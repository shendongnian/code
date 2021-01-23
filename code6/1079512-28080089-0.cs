    [HttpGet]
    public ActionResult WypelnijFormularz(int doctor, string date, string hour, string minute)
    {
         RegisterVisitModel model = new RegisterVisitModel();
         model.doctor = DoctorRepository.GetDoctorByID(doctor);
         model.dateVisit = DateTime.ParseExact(date+" "+hour+":"+minute+":00", "yyyy-MM-dd HH:mm:ss", null);
         //Check if an appointment exists on that day
         if(DoctorRepository.IsAppointmentExist(model.dateVisit))
         {
               //Redirect to error page
               return RedirectToAction("Index", "Error");
         }
         return View(model);
    }
