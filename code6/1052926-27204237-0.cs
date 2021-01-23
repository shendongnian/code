    public abstract class BaseTimerHandler
    {
        private readonly Timer m_Timer;
        public BaseTimerHandler(int interval)
        {
            m_Timer = new Timer();
            m_Timer.Interval = interval;
            m_Timer.Elapsed += TimerElapsed;
            m_Timer.Start();
        }
 
        protected abstract TimerElapsed(object sender, ElapsedEventArgs e);
        //TODO unsubscribe from Elapsed in Dispose method.
    }
    public class TimerAHandler : BaseTimerHandler
    {
        private const int _INTERVAL = 1000;
        public TimerAHandler() : base(_INTERVAL) { }
        protected override TimerElapsed(object sender, ElapsedEventArgs e)
        {
            //send message A
        }
    }
    public class TimerBHandler : BaseTimerHandler
    {
        private const int _INTERVAL = 3000;
        public TimerBHandler() : base(_INTERVAL) { }
        protected override TimerElapsed(object sender, ElapsedEventArgs e)
        {
            //send message B
        }
    }
    public class TimerCHandler : BaseTimerHandler
    {
        private const int _INTERVAL = 5000;
        public TimerCHandler() : base(_INTERVAL) { }
        protected override TimerElapsed(object sender, ElapsedEventArgs e)
        {
            //send message C
        }
    }
