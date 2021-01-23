    class a
    {
        private double x;
        public double X
        {
            get 
            {
                return this.x;
            }
            set
            {
                if (value != null) // warning, see below
                {
                    this.x = value;
                }
            }
        }
    }
