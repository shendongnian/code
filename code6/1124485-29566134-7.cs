    public class ScheduleFacade
    {
        private ScheduleRepository _repository;
        public ScheduleFacade()
        {
            _repository = new ScheduleRepository();
        }
        public ScheduleSetting GetScheduleById(string scheduleId)
        {
            if (!string.IsNullOrEmpty(scheduleId))
            {
                _repository.SetSomething();
                ScheduleSetting settings = _repository.GetScheduleById(scheduleId);
                _repository.UnSetSomething();
                return LoadScheduleSettings(settings);
            }
            else
            {
                throw new ArgumentException("The scheduleId parameter cannot be empty.");
            }
        }
        private ScheduleSetting LoadScheduleSettings(ScheduleSetting settings)
        {
            //...code ....
        }
    }
