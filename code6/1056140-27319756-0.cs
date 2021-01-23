    DatePicker datePickerWithBlackoutDates = new DatePicker();
    
    datePickerWithBlackoutDates.DisplayDateStart = new DateTime(2009, 8, 1);
    datePickerWithBlackoutDates.DisplayDateEnd = new DateTime(2009, 8, 31);
    datePickerWithBlackoutDates.SelectedDate = new DateTime(2009, 8, 10);
    
    datePickerWithBlackoutDates.BlackoutDates.Add(
        new CalendarDateRange(new DateTime(2009, 8, 1), new DateTime(2009, 8, 2)));
    datePickerWithBlackoutDates.BlackoutDates.Add(
        new CalendarDateRange(new DateTime(2009, 8, 8), new DateTime(2009, 8, 9)));
    datePickerWithBlackoutDates.BlackoutDates.Add(
        new CalendarDateRange(new DateTime(2009, 8, 15), new DateTime(2009, 8, 16)));
    datePickerWithBlackoutDates.BlackoutDates.Add(
        new CalendarDateRange(new DateTime(2009, 8, 22), new DateTime(2009, 8, 23)));
    datePickerWithBlackoutDates.BlackoutDates.Add(
        new CalendarDateRange(new DateTime(2009, 8, 29), new DateTime(2009, 8, 30)));
    
    datePickerWithBlackoutDates.DateValidationError +=
    new EventHandler<DatePickerDateValidationErrorEventArgs>(DatePicker_DateValidationError);
