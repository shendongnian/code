    public class Day
    {
        public int Temperature { get; set; }
        public bool Frost { get { return Temperature < 0; } }
    
        public Day(int temperature)
        {
            Temperature = temperature;
        }
    }
