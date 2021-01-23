    private Timer scrollTimer = new Timer();
    private int scrollJump = 0;
    public Form1() {
      InitializeComponent();
      panel1.AllowDrop = true;
      panel1.AutoScroll = false;
      panel1.AutoScrollMinSize = new Size(0, 1000);
      panel1.MouseMove += panel1_MouseMove;
      panel1.DragEnter += panel1_DragEnter;
      panel1.DragOver += panel1_DragOver;
      panel1.QueryContinueDrag += panel1_QueryContinueDrag;
      scrollTimer.Tick += scrollTimer_Tick;
    }
