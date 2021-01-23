    if (SortedDatesDays.Count() == 0)
            {
                var addDisplayObjectDatesYear = new DisplayObjectDates();                 
                addDisplayObjectDatesYear.fulldatetime = contextreturned.change_time;
                addDisplayObjectDatesYear.CountedDate = 1;
                SortedDatesDays.Add(addDisplayObjectDatesYear);
            }
            else
            {
                foreach (var VARIABLE in SortedDatesDays)
                {
                    if (VARIABLE.fulldatetime.Date == contextreturned.change_time.fulldatetime.Date)
                    {
                        VARIABLE.CountedDate = VARIABLE.CountedDate++;
                    }
                    else
                    {
                        var addDisplayObjectDatesYear = new DisplayObjectDates();
                        addDisplayObjectDatesYear.fulldatetime = contextreturned.change_time;
                        addDisplayObjectDatesYear.CountedDate = 1;
                        SortedDatesDays.Add(addDisplayObjectDatesYear);
                    }
                }
            } 
 
          
