        bool GetPropByName(AdvOnCall item, string column)
        {
           return (bool)AdvOnCall.GetType().GetProperty(column).GetValue(item, null);
        }
        var column = "Adv" + dayOfWeek + time;
        var employeesOnCall = from r in db.AdvOnCalls
                              where GetPropByName(r, column)
                              select r.ChartEmployee;
