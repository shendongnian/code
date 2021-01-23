    public class TimerHandler
    {
        private readonly Timer m_Timer;
        private readonly Action m_Elapsed;
        public BaseTimerHandler(int interval, Action sendMessage)
        {
            if (sendMessage == null)
                throw new ArgumentNullException("sendMessage", "Must provide send message");
            m_Timer = new Timer();
            m_Timer.Interval = interval;
            m_Timer.Elapsed += TimerElapsed;
            
            m_Elapsed = sendMessage;
            m_Timer.Start();
        }
 
        private TimerElapsed(object sender, ElapsedEventArgs e){
        {
            m_Elapsed();
        }
        //TODO unsubscribe from Elapsed in Dispose method.
    }
    var timerA = new TimerHandler(1, () => { //send message A });
    var timerB = new TimerHandler(3, () => { //send message B });
    var timerC = new TimerHandler(5, () => { //send message B });
 
