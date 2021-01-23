    public Class class
    {
    
        private bool _shouldHandle = true;
        public void EventHandler(object Sender, EventArgs e)
        {
          if(_shouldHandle)
          {
            _shouldHandle = false;
            //make change
            _shouldHandle = true;
          }
        }
    }
