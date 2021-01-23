    public abstract Bakeable<T> : IBakeable<T>
    {
        event EventHandler OnCooked;
        
        public Cooked(object sender)
        {
            var handler = this.OnCooked;
            if (handler != null)
            {
                handler(sender, new EventArgs());
            }
        }
    }
