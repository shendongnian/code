     TimeSpan workTimeBegin = new TimeSpan(04, 00, 00);
     TimeSpan workTimeEnd = new TimeSpan(18, 00, 00);
     DateSpan dateRange1 = new DateSpan(new DateTime(2012, 01, 01, 07, 00, 00), new DateTime(2012, 01, 03, 15, 00, 00));
     DateSpan dateRange2 = new DateSpan(new DateTime(2012, 01, 01, 02, 00, 00), new DateTime(2012, 01, 03, 20, 00, 00));
     DateSpan dateRange3 = new DateSpan(new DateTime(2012, 01, 01, 04, 00, 00), new DateTime(2012, 01, 03, 23, 00, 00));
     DateSpan dateRange4 = new DateSpan(new DateTime(2012, 01, 01, 23, 00, 00), new DateTime(2012, 01, 03, 09, 00, 00));
     DateSpan dateRange5 = new DateSpan(new DateTime(2012, 01, 02, 12, 00, 00), new DateTime(2012, 01, 02, 20, 00, 00));
     DateSpan dateRange6 = new DateSpan(new DateTime(2012, 01, 02, 20, 00, 00), new DateTime(2012, 01, 03, 03, 00, 00));
     DateSpan dateRange7 = new DateSpan(new DateTime(2012, 01, 02, 15, 00, 00), new DateTime(2012, 01, 03, 00, 00, 00));
    Debug.WriteLine(String.Format("dateRange1: {0} ({1})", dateRange1.GetWorkTimeSpan(workTimeBegin, workTimeEnd), dateRange1.GetWorkTimeSpan(workTimeBegin, workTimeEnd).TotalHours));
    Debug.WriteLine(String.Format("dateRange2: {0} ({1})", dateRange2.GetWorkTimeSpan(workTimeBegin, workTimeEnd), dateRange2.GetWorkTimeSpan(workTimeBegin, workTimeEnd).TotalHours));
    Debug.WriteLine(String.Format("dateRange3: {0} ({1})", dateRange3.GetWorkTimeSpan(workTimeBegin, workTimeEnd), dateRange3.GetWorkTimeSpan(workTimeBegin, workTimeEnd).TotalHours));
    Debug.WriteLine(String.Format("dateRange4: {0} ({1})", dateRange4.GetWorkTimeSpan(workTimeBegin, workTimeEnd), dateRange4.GetWorkTimeSpan(workTimeBegin, workTimeEnd).TotalHours));
    Debug.WriteLine(String.Format("dateRange5: {0} ({1})", dateRange5.GetWorkTimeSpan(workTimeBegin, workTimeEnd), dateRange5.GetWorkTimeSpan(workTimeBegin, workTimeEnd).TotalHours));
    Debug.WriteLine(String.Format("dateRange6: {0} ({1})", dateRange6.GetWorkTimeSpan(workTimeBegin, workTimeEnd), dateRange6.GetWorkTimeSpan(workTimeBegin, workTimeEnd).TotalHours));
    Debug.WriteLine(String.Format("dateRange7: {0} ({1})", dateRange7.GetWorkTimeSpan(workTimeBegin, workTimeEnd), dateRange7.GetWorkTimeSpan(workTimeBegin, workTimeEnd).TotalHours));
