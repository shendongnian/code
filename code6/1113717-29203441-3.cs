    public class YogaSpaceEvent
    {
        // Function and Data Members
    }
    public interface IYogaSpaceEventRepository
    {
        IQueryable<YogaSpaceEvent> FindEvents(DateTime start, DateTime end);
    }
    public class DiaryEvent
    {
        private IYogaSpaceEventRepository _repository;
    
        public DiaryEvent(IYogaSpaceEventRepository repository)
        {
            this._respository = repository;
        }
    
        public static List<DiaryEvent> LoadAllAppointmentsInDateRange(double start, double end)
        {
            // Call appropriate method on _repository
        }
    }
