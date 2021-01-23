    Class TestClass{
    
        private static DateTime _TimeNow;
        private static Timer timer;
    
        public TestClass(){
           timer = new Timer();
           timer.Interval = 1000;
           _TimeNow = DateTime.UtcNow; //don't forget this is a variable and not a timer
           timer.Tick = new EventHalndler(timer_tick);
           timer.Start();
        }
        private void timer_tick(object sender, EventArgs e){
           _TimeNow = DateTime.UtcNow;
     }
