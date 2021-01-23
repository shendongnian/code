    public class CubeProjectile
    {
    
        private PictureBox box;
    
        public CubeProjectile(PictureBox box1)
        {
            box = box1;
            Timer Update = new Timer();
            Update.Interval = 1;
            Update.Tick += new EventHandler(Timer_Tick);
            Update.Start();
        }
    
        void Timer_Tick(object sender, EventArgs e)
        {
            Point loc = new Point(box.Location.X, box.Location.Y);
            box.SetBounds(loc.X + 1, loc.Y, box.Width, box.Height);
        }
    
    }
     CubeProjectile cb1 = new CubeProjectile(pic1);
     CubeProjectile cb2 = new CubeProjectile(pic2);
