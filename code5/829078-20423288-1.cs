    static int HoursOfMonth(MonthOrder month, PersonTimeSheet person)
    {
        switch(month)
        {
            case MonthOrder.JAN:
                return person.Jan;
            case MonthOrder.FEB:
                return person.Feb;
            // Hopefully you get the point.
        }
    }
