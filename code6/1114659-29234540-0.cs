       DateTime date1 = appointment.AppointmentDateTime.Date;
       IEnumerable<Appointment> ApntDate = 
               db.Appointment.ToList()
               .FirstOrDefault(q=>q.AppointmentDateTime.Date == date1);                   
         if(ApntDate!=null){//book new}
         else{return Content("You have already booked!");}
