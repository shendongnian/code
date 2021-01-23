    [HttpGet]
    //public IHttpActionResult Get()
    public dynamic Get()
    {
          var appointment1 = from prescription in db.Prescriptions
                           where prescription.appointment == "15/01/2015"
                           from consultation in prescription.Consultations
                           select new
                           {
                               ID = prescription.id,
                               Name = prescription.patient_name,
                               Contact = prescription.patient_contact,
                               Task = prescription.next_task
                           };
        var appointment2 = from consultation in db.Consultations
                           where consultation.next_date == "15/01/2015"
                           select new
                           {
                               ID = consultation.Prescription.id,
                               Name = consultation.Prescription.patient_name,
                               Contact = consultation.Prescription.patient_contact,
                               Task = consultation.next_task
                           };
        //var finalAppointments = appointment1.Concat(appointment2);
       // return finalAppointments;    //rather I'd use below line...
       //   return Ok(finalAppointments); // here your are concatenating two objects.
       return new {appointment1 ,appointment2 }; // you can send multiple objects...
    
    }
