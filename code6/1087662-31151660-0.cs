    class Student {
            public int TeacherId { get; set; }
            [Required, ForeignKey("TeacherId")]
            public virtual Teacher Teacher { get; set; }
    }
