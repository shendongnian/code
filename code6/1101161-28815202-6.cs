    public class TimelineVolumetry
    {
        public int AllowedWeeks { get; set; }
        //relational properties
        [Key, ForeignKey("User")]
        public int User_ID { get; set; }
        public User User { get; set; }
        public TimelineVolumetry()
        {
            AllowedWeeks = 0;
        }
    }
