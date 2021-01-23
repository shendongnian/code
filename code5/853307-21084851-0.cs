    var Result = from Period in context.PeriodCosts
                 join Name in context.Name
                     on new { ID = Period.ID, CCID = Period.CCID }
                     equals new { ID = Name.PeriodID, CCID = Name.CCID }
                 Period.CCID equals Name.CCID"
                 select Name;
