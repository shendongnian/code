    public class Account
    {
        public ExtendedBindingList<User> Users { get; private set; }
        public Account()
        {
            Users = new ExtendedBindingList<User>();
            Users.ListChanged += Users_ListChanged;
        }
        private void Users_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.ItemDeleted)
                return;
            foreach (var group in UserGroups)
                group.Users.Remove(Users.LastRemovedItem);
        }
        // ...
     }
