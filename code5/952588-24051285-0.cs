    public class CSService : IClassStudentsService
    {
        public CSService() {
             Exceptions = new List<ExceptionPairs>();
        }
        public List<ExceptionPairs> Exceptions { get; set; }
    }
