    public class PacketPoller
    {
        public event EventHandler Tick;
    
        private Timer m_timer;
    
        public void Start()
        {
            m_timer = new Timer(OnTick, null, 0, 1);
            m_timer.InitializeLifetimeService();
        }
    
        public void OnTick(object state) 
        { 
        	var tick = this.Tick;
        	if (tick != null)
        		tick();
        }
    }
