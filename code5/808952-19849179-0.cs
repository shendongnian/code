    public JsonResult CumLeadsParameters(CumLeadsReport cumLeads)
    {
        var weeks = (cumLeads.EndDate - cumLeads.StartDate).TotalDays / 7;
        if (!(weeks > 0))
        {
            // means I have less than a week so calculate days and make it as a weeek and 
            var startDate = cumLeads.StartDate.Date;
            var endDate = startDate.AddDays(7).AddSeconds(-1);
            var x = _retailerStatsRepository.GetAllRetailersForManufacturerCountrySelectedDates(
                        manufacturer.Id,
                        country.Id,
                        startDate,
                        endDate);
        }
        else
        {
            cumLeads.StartDate = cumLeads.StartDate.Date;
            while (weeks > 0)
            {
                weekCounter++;
                cumLeads.EndDate = cumLeads.StartDate.AddDays(7).AddSeconds(-1);
                var x = _retailerStatsRepository.GetAllRetailersForManufacturerCountrySelectedDates(
                            manufacturer.Id,
                            country.Id,
                            cumLeads.StartDate,
                            cumLeads.EndDate);
                tuple.Add(new Tuple<int, IQueryable<RetailerStat>, DateTime, DateTime>(
                    weekCounter,
                    x,
                    cumLeads.StartDate,
                    cumLeads.EndDate));
            }
        }
    }
