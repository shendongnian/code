    public class Service
    {
        public delegate void TimerTickHandler(int hours, int minutes);
        public event TimerTickHandler TimerTick;
        .
        .
        .
        private void OnTick(object sender, EventArgs e)
        {
          ...
          
          if (TimerTick != null)
               TimerTick(hours, minutes);
        }
    }
