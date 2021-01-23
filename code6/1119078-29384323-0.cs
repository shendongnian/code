    public class InvalidationUserControl : UserControl
    {
       bool _isInvalid = false;
       int _data;
       Timer t = new Timer();
       public InvalidationUserControl()
       {
          InitializeComponent();
          t.Interval = 100;  // Go ahead an play with this number, the higher
                             // it is the greater the latency
          t.Tick += t_Tick;
          t.Start();
       }
       void InvalidateIfNeeded()
       {
          _isInvalid = true;
       }
       void t_Tick(object sender, EventArgs e)
       {
          if (_isInvalid)
          {
              _isInvalid = false;
              Invalidate();
          }
       }
       public int Data
       {
           get { return _data; }
           set
           {
               _data = value;
               InvalidateIfNeeded();
           }
       }
    }
