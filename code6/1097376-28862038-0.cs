        public class ScheduledVenueDTO
        {
            public int VenueId { get; set; }
            public string Name { get; set; }
        }
        public Dictionary<int, string> GetScheduledVenuesFuture()
        {
            var venues = from v in _sp.CurrentSessionOn(DatabaseName.SMS).Query<Venue>()
                         join s in _sp.CurrentSessionOn(DatabaseName.SMS).Query<ScheduledClass>()
                                 on v.VenueId equals s.Venue.VenueId
                         where s.CourseDate >= _cac.Now
                                 && s.Closed == false
                                 && s.Canceled == false
                         select new
                         {
                             v.VenueId,
                             v.Name
                         };
            var svd = venues
                .GroupBy(v => new { v.VenueId, v.Name})
                .Select(v => new ScheduledVenueDTO() {
                    VenueId = v.Key.VenueId,
                    Name = v.Key.Name
                });
            return svd.ToDictionary(v => v.VenueId, v => v.Name);
        }
