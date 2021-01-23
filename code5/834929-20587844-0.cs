    //define some variables first, note that don't rely on the 
    //ProgressBarRenderer.ChunkThickness and ProgressBarRenderer.ChunkSpaceThickness
    //because they are actually small and using our own variables will allow us to change
    //the chunk size easily.
    int chunkThickness = 13;
    int chunkSpace = 1;
    Rectangle chunkRect = new Rectangle(0, 0, chunkThickness,
                              toolStripProgressBar1.ProgressBar.Height-4);
    //The hosted ProgressBar's Paint event handler
    private void progressBar_Paint(object sender, PaintEventArgs e){
      chunkRect.Location = Point.Empty;
      chunkRect.Offset(2, 2);                
      var percent = (float) toolStripProgressBar1.Value / toolStripProgressBar1.Maximum;
      var valueLength = percent * toolStripProgressBar1.ProgressBar.Width;
      var chunks = (int) (valueLength / (chunkThickness + chunkSpace) + 0.5f);
      for (int i = 0; i < chunks; i++) {
         //I use the green color for the chunk color, it's up to you.
         e.Graphics.FillRectangle(Brushes.Green, chunkRect);                    
         chunkRect.Offset(chunkThickness + chunkSpace, 0);
      }
      ControlPaint.DrawBorder3D(e.Graphics, toolStripProgressBar1.ProgressBar.ClientRectangle,
                               Border3DStyle.SunkenOuter);
    }
    //Now in your form constructor, just add this code to end up everything before
    //trying running the code:
    public Form1(){
       InitializeComponent();
       //do this to allow the Paint event to be fired and more ...
       typeof(Control).GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic |
                                             System.Reflection.BindingFlags.Instance)
                      .Invoke(toolStripProgressBar1.ProgressBar, 
                              new object[] {ControlStyles.UserPaint |
                                            ControlStyles.OptimizedDoubleBuffer, true });
       //hook up the progressBar_Paint event handler for the hosted ProgressBar
       toolStripProgressBar1.ProgressBar.Paint += progressBar_Paint;
    }
