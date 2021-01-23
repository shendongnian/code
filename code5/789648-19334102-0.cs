    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    public partial class uscEstimate : UserControl
    {
        // Declare an EventHandler delegate that we will use to publish and subscribe to our event
        // We declare this as taking a UserControl as the event argument
        // The UserControl will be passed along when the event is raised
        public EventHandler<UserControl> AddNewItemEventHandler;
    
        public uscEstimate()
        {
            InitializeComponent();
        }
    
        // Create a new UserControl and raise (publish) our event
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var control = new uscEstimate();
            RaiseAddNewItemEventHandler(control);
        }
    
        // We use this to raise (publish) our event to anyone listening (subscribed) to the event
        private void RaiseAddNewItemEventHandler(UserControl ucArgs)
        {
            var handler = AddNewItemEventHandler;
            if (handler != null)
            {
                handler(this, ucArgs);
            }
        }
    }
