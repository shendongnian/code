    // Assuming Visits is an IEnumerable<Visit>
    var userVisits = from v in Visits
                     group v by v.User into groupedVisits
                     select new { // AnonymousType1
                         User = groupedVisits.Key,
                         Visits = from gv in groupedVisits
                                  group gv by gv.DateScheduled.Date into dateVisits
                                  select new { // AnonymousType2
                                      DateScheduled = dateVisits.Key,
                                      Customers = from dv in dateVisits
                                                  select dv.CustomerId
                                  }
                     }
