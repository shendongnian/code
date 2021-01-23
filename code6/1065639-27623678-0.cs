    ChartPanel panel;
    public ChartPanel Panel
    { 
        get{ return panel; } 
        set{ 
             if(panel != null)
                panel.Paint -= CloneAspect;
             panel = value;
             panel.Paint += CloneAspect;
        }
    }
