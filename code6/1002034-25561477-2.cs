    DateTime? dt;
    
    if(dt.HasValue) {
     //has date
     if(dt.Value.TimeOfDay.TotalSeconds == 0) {
       // display datepicker
     } else {
       // display timepicker
     }
    } else {
    
    // show date time picker
    }
