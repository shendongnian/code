     private void Button_Click(object sender, RoutedEventArgs e)
     {
          Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, 
                new Action(() => {
                    Person.FirstName = "John";
                }));
          // Run a lengthy operation here
     }
