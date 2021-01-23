    public interface IEnrollment<T> where T:IEnrollmentToRegion
        {
            bool IsGood { get; set; }
            ICollection<T> Regions { get; set; }
        }
    
        public interface IEnrollmentToRegion
        {
            int RegionId { get; set; }
        }
    
        public class ByRegion : IEnrollmentToRegion
        {
            public int RegionId { get; set; }
        }
    
        public class Enrollment : IEnrollment<ByRegion>
        {
            public bool IsGood { get; set; }
            public ICollection<ByRegion> Regions { get; set; }
        }
    
        public class Main
        {
            public void DoSomething()
            {
                var a = typeof(IEnrollmentToRegion).IsAssignableFrom(typeof(ByRegion));
                var b = typeof(ICollection<IEnrollmentToRegion>).IsAssignableFrom(typeof(ICollection<ByRegion>));
    
                var e = new Enrollment();
                e.Regions = new List<ByRegion>() { new ByRegion { RegionId = 10 } };
    
                if (isEnrolled(e, c => c.Any(l => l.RegionId == 10)))
                {
                    //This line gets hit
                }
            }
    
            private bool isEnrolled<T>(IEnrollment<T> enrollment, Func<ICollection<T>, bool> test) where T : IEnrollmentToRegion
            {
                return test(enrollment.Regions);
            }
