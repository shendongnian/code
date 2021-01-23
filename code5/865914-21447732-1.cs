    public static List<vwData> GetAllData(string startDate, string endDate)
    {
      DateTime dtStart = Convert.ToDateTime(startDate).Date;
      DateTime dtEndDate = Convert.ToDateTime(endDate).Date;
      var entities = new DataEntities();
      var query = from c in entities.vwData
                let eventDate = EntityFunctions.TruncateTime(c.EventCreateDate)
                orderby c.EventCreateDate ascending
                thenby c.StartDateTime ascending
                where eventDate >= dtStart && eventDate <= dtEndDate
                select c;
      return query.ToList();
    }
