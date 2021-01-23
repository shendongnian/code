    class vu_Position
    {
        public int? JOB_ID { get; set; }
        public string JOB { get; set; }
    }
    List<vu_Position> Positions = new List<vu_Position>
    {
        new vu_Position { JOB_ID = null, JOB = "A"},
        new vu_Position { JOB_ID = 1, JOB = "B"},
        new vu_Position { JOB_ID = 2, JOB = "C"},
        new vu_Position { JOB_ID = 3, JOB = null}
    };
