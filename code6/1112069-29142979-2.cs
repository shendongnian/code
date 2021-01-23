    class Racer
    {
        public string name, surname;
        public Time Time { get; set; }
        public override string ToString()
        {
            return surname + name + "(" + Time.ToString() + ")";
        }           
    }
    class Time
    {
        DateTime startTime, finishTime, result;
    
        public override string ToString()
        {
            TimeSpan elapsedTime = finishTime - startTime;
            return elapsedTime.ToString();
        }
    } 
