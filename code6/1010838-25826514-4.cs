        public List<Room> Rooms
        {
            get
            {
                return new List<Room> 
                { 
                    new Room{ Name = "A"} , 
                    new Room{ Name = "B"}
                };
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var rooms = listView_RoomList.Items.Cast<Room>().ToList();
            var generator = listView_RoomList.ItemContainerGenerator;
            ListViewItem container = (ListViewItem)generator.ContainerFromItem(rooms[0]);
            PasswordBox pwd = (PasswordBox)VisualTreeHelperExtensions.FindVisualChild<PasswordBox>(container);
            string password = pwd.Password;
        }
