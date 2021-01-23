    // Implement this method to serialize data. The method is called  
    // on serialization. 
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        var smallest = (TimeTableXmlList.Count < ScheduleList.Count ?? TimeTableXmlList.Count : ScheduleList.Count )
        for(int x = 0; x < smallest; x++)
        {
            var time = TimeTableXmlList.ElementAt(x);
            var schedule = ScheduleList.ElementAt(x)
                    // Use the AddValue method to specify serialized values.
            info.AddValue("timetable", time, typeof(TimeTableXml));
            info.AddValue("schedule", schedule , typeof(ScheduleXml));
        }
    }
