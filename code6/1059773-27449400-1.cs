    class SurfaceManager
    {
        private Control _defaultCtrl;
        private bool _currentDefault;
        private Control _surface;
        void SurfaceManager(Control _surface, Control defaultCtrl) 
        {
            _surface = surface;
            _defaultCtrl = defaultCtrl;
            _surface = surface.Controls.Add(_defaultCtrl);
            _currentDefault = true;
        }
        public Control Add(Control ctrl)
        {
            Control c = null; // Returning removed control so you can do something else with it
            if (_surface.Controls.Count > 0)
            {
                if (!_currentDefault)
                    c = _surface.Controls[0];
                _surface.Controls.Clear();
            }           
            _surface = surface.Controls.Add(ctrl);
            _currentDefault = false;
            Return c;
        }
        
        public Control Remove()
        {
            if (_currentDefault) Return // Current is default - do nothing
            
            Control c = null; // Returning removed control so you can do something else with it
            if (_surface.Controls.Count > 0)
            {
                c = _surface.Controls[0];
                _surface.Controls.Clear();
            }           
            _surface = surface.Controls.Add(_defaultCtrl);
            _currentDefault = true;
            Return c;
                        
        }
        
    }
