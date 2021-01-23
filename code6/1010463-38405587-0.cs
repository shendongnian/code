        private void hideProgressBar ( )
        {
            this.Dispatcher.Invoke ( (Action) ( ( ) => {
               progressBar.Visibility = Visibility.Hidden;
            } ) );
        }
        private void showProgressBar ( )
        {
            this.Dispatcher.Invoke ( (Action) ( ( ) => {
               progressBar.Visibility = Visibility.Visible;
            } ) );
        }
