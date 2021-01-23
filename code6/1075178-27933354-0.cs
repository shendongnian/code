        //In App.xaml.cs
        public MediaElement m = new MediaElement();
        
         private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Set the properties of the MediaElement Control here
            Application.Current.Resources.Add("1", m); //Add it to the Application Resources
           
        }        
        //In MainPage.xaml.cs say for a Button Click Event
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;
            obj.m.Play();
        }
 
