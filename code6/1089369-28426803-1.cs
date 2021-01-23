    class GroupAverage
    {
        public Level Level { get; set; }
        public float Avg { get; set; }
    }
	var result = students.GroupBy(s => s.Level)
						 .Select(g => new GroupAverage { Level=g.Key, Avg=g.Average(s => s.GPA) } );
