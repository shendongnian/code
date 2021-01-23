    private List<Schedule> _AllSchedules;
    public List<Schedule> AllSchedules 
    {
        get 
        {
            if (_AllSchedules == null)
            {
                _AllSchedules = new List<Schedule>();
                Schedule s1 = new Schedule(1);
                Schedule s2 = new Schedule(15);
                Schedule s3 = new Schedule(29);
                Schedule s4 = new Schedule(DayOfWeek.Monday);
                Schedule s5 = new Schedule(DayOfWeek.Wednesday);
                Schedule s6 = new Schedule(DayOfWeek.Friday);
                _AllSchedules.AddRange(new[] { s1, s2, s3, s4, s5, s6 });
            }
            return _AllSchedules;
        }
    }
