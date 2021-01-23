    public class Derivedclass : Baseclass
    {
        private int mX = 0;
        private int mY = 0;
        public int X
        {
            get { return mX; }
            set
            {
                mX = value;
                base.Total = base.Total + mX;
                OnPropertyChanged("Total");
            }
        }
        public int Y
        {
            get { return mY; }
            set
            {
                mY = value;
                base.Total = base.Total + mY;
                OnPropertyChanged("Total");
            }
        }
    }
