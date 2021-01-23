    class dog
    {
        public int startpost;
        public int TrackLenght = 620;
        public PictureBox dogpic = null;
        public int Location = 0;
        public Random random=new Random();
    
        public void ResetStart()
        { 
            dogpic.Location = new System.Drawing.Point(40, startpost);
            timer.Enabled=true;
        }
    
        public bool testrun()
        {
            Point p = dogpic.Location;
    
            if (p.X < TrackLenght)
            {
                int distance = random.Next(5);
    
                p.X = p.X + distance;
                dogpic.Location = p;
                Location = dogpic.Location.X;
                return false;
            }
            else
            {
                MessageBox.Show(dogpic.Name + " win");
                timer.Enabled=false;    
                return true;
            }
        }
    }
