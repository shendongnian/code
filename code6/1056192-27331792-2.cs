        public void Start()
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.Visibility = System.Windows.Visibility.Visible;
            }), System.Windows.Threading.DispatcherPriority.Normal);
            
        }
