        public class CustomProgressBar : ProgressBar
        {
            public event EventHandler ReachedMinimum;
            public event EventHandler ReachedMaximum;
            public event EventHandler ValueChanged;            
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 0x402)//PBM_SETPOS = WM_USER + 2
                {     
                   EventHandler handler = ValueChanged;
                   if(handler != null) handler(this, EventArgs.Empty);
                   handler = ReachedMinimum;                    
                   if (Value == Minimum && handler!=null) handler(this, EventArgs.Empty);
                   handler = ReachedMaximum;
                   if (Value == Maximum && handler != null) handler(this, EventArgs.Empty);
                } 
            }
        }
        //Use it
        customProgressBar1.ReachedMaximum += (s,e) => {
              MessageBox.Show("Reached maximum!");
        };
        //... the same for other events
