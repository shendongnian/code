        private TimeSpan startTimeSpan = new TimeSpan(0,5,0,0);
        private Timer timer = new Timer();
      public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeDecrease = TimeSpan.FromSeconds(1);
            startTimeSpan = startTimeSpan - timeDecrease;
            ribbon.InvalidateControl("timerLabel");
        }
        public string timerLabel_getLabel(Office.IRibbonControl control)
        {
            return startTimeSpan.ToString();
        }
        //public void button1_onAction(Office.IRibbonControl control)
        //{
        //    timer.Start();
        //}
