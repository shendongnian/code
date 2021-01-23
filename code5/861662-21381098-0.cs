      private TimeSpan startTimeSpan = new TimeSpan(0,5,0,0);
    public string timerLabel_getLabel(Office.IRibbonControl control)
            {
                return startTimeSpan.ToString();
            }
    
            public void button1_onAction(Office.IRibbonControl control)
            {
                TimeSpan timeDecrease = TimeSpan.FromSeconds(1);
                startTimeSpan = startTimeSpan - timeDecrease;
                ribbon.InvalidateControl("timerLabel");
            }
