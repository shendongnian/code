        public void Dropped()
        {
            this.events.PublishOnUIThread(new ItemDroppedEvent(this.X, this.Y, this.Width, this.Height, this.ID));
        }
        public void Moved(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
