        private MediaElement _mediaElementObject = new MediaElement();
        public MediaElement MediaElementObject
        {
            get { return _mediaElementObject; }
            set
            {
                _mediaElementObject = value;
                NotifyOfPropertyChange(() => MediaElementObject);
            }
        }
    
        public void ButtonPlay()
        {
            MediaElementObject.Source =new Uri( @"C:\Users\admin\Videos\XXXXXX.wmv");
            MediaElementObject.LoadedBehavior = MediaState.Manual;
            MediaElementObject.UnloadedBehavior = MediaState.Manual;
            MediaElementObject.Play();
        }     
    
        public void ButtonStop()
        {
            MediaElementObject.Stop();
        }
        public void ButtonForward()
        {
            MediaElementObject.Position = _mediaElementObject.Position + TimeSpan.FromSeconds(30);
        }
        public void ButtonBack()
        {
            MediaElementObject.Position = _mediaElementObject.Position - TimeSpan.FromSeconds(30);
        }
