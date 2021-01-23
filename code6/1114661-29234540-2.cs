       DateTime date1 = appointment.AppointmentDateTime.Date;
       var ApntDate = 
               db.Appointment
               .FirstOrDefault(q=>q.AppointmentDateTime.Date == date1);                   
         if(ApntDate!=null){//book new}
         else{return Content("You have already booked!");}
