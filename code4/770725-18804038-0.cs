        public class CustomProgressBar : ProgressBar
        {
            public event EventHandler ReachedMinimum;
            public event EventHandler ReachedMaximum;
            public event EventHandler ValueChanged;
            public new int Value
            {
                get { return base.Value; }
                set
                {
                    if(base.Value != value){
                      base.Value = value;
                      EventHandler handler = ValueChanged;
                      if(handler != null) handler(this, EventArgs.Empty);
                      handler = ReachedMinimum;                    
                      if (value == Minimum && handler!=null) handler(this, EventArgs.Empty);
                      handler = ReachedMaximum;
                      if (value == Maximum && handler != null) handler(this, EventArgs.Empty);
                    }
                }
            }
        }
        //Use it
        customProgressBar1.ReachedMaximum += (s,e) => {
              MessageBox.Show("Reached maximum!");
        };
        //... the same for other events
