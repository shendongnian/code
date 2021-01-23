     ModelState.Remove("StartTime"); 
     ModelState.Remove("EndTime");
     bookingViewModel.StartTime = Convert.ToDateTime(startTime);
     bookingViewModel.EndTime = Convert.ToDateTime(endTime);
     return View("Booking", bookingViewModel);
