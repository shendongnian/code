    Dispatcher.Invoke( new Action( () =>
         {
             lab1.Visibility = Visibility.Visible;
             lab2.Visibility = Visibility.Hidden;
             lab3.Visibility = Visibility.Hidden;
         } ) );
