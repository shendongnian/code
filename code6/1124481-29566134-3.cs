    public class ScheduleRepository : Repository<AppContext>
    {
        public ScheduleRepository()
            :base(new AppContext())
        {
        }
        public Schedule GetById(int id) { 
            this.Context.Schedules. (....) // blah blah
        }
        protected override void OnDispose(bool disposing)
        {
            // if you are working with any thing that you must free it up
            // do it here, but not the context
        }
    }
