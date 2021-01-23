    public class StayOnTillAppDies : IStayOnTillAppDies
    {
        private readonly Func<IDiesWhenRequestObjectDies> resolver;
        public StayOnTillAppDies(Func<IDiesWhenRequestObjectDies> resolver)
        {
            this.resolver = resolver;
        }
    }
