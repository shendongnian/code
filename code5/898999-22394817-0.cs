        bool _hasShown;
    
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
    
            if (!_hasShown)
            {
                 _hasShown = true;
                 // void OnShown() code here!
            }
        }
