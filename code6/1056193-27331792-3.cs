        public void Stop()
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.Visibility = System.Windows.Visibility.Collapsed;
            }), System.Windows.Threading.DispatcherPriority.Normal);
        }
    }
    }
