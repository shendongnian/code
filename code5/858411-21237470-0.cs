    class Variables
    {
        Dictionary<DayOfWeek, string> DayText = new Dictionary<DayOfWeek, string>()
        {
           {DayOfWeek.Monday, string.Format("Monday's Timetable{0}P1 English{0}P2 Maths{0}P3 History{0}P4 Computing", Environment.NewLine)},
           {DayOfWeek.Tuesday, string.Format("Tuesday's Timetable{0}P1 Science{0}P2 Geography{0}P3 History{0}P4 Maths", Environment.NewLine)},
           {DayOfWeek.Wednesday, string.Format("Wednesday's Timetable{0}P1 Science{0}P2 Geography{0}P3 History{0}P4 Maths", Environment.NewLine)},
           {DayOfWeek.Thursday, string.Format("Thursday's Timetable{0}P1 Science{0}P2 Geography{0}P3 History{0}P4 Maths", Environment.NewLine)},
           {DayOfWeek.Friday , string.Format("Friday 's Timetable{0}P1 Science{0}P2 Geography{0}P3 History{0}P4 Maths", Environment.NewLine)},
        };    
    
    }
