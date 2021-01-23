    public class MyPictureBox : PictureBox, IDisposable
    {
        private Timer _timer1 = new Timer();
        private Timer _timer2 = new Timer()
        
        //more of your stuff 
        ~MyPictureBox ()
        {
            Dispose(false);
        }
   
        protected override void Dispose(bool disposing)
        {
             //clean up unmanaged here
            if(disposing)
            {
                _timer1.Dispose();
                _timer2.Dispose();
            }
            base.Dispose(disposing);
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
