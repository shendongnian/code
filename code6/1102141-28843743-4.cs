        public class Reservation
        {
            public DateTime ArrivalDate { get; set; }
            public DateTime LeaveDate { get; set; }
        }
        public class CampingSpot
        {
            public virtual Reservation Reservation { get; set; }
        }
        public class TestClass
        {
            public void Test()
            {            
                var CampingSpots = new List<CampingSpot>().AsQueryable();
                var ArrivalDate = new DateTime();
                var LeaveDate = new DateTime();
                var res = CampingSpots.Where(c => DbFunctions.TruncateTime(c.ArrivalDate) >= DbFunctions.TruncateTime(ArrivalDate)
                                               && DbFunctions.TruncateTime(c.LeaveDate) <= DbFunctions.TruncateTime(LeaveDate)
                                               && c.Reservation == null)
                                     ).ToList();                
            }
        }
