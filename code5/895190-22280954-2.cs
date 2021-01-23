    using System.Collections.ObjectModel;
    namespace SOWPF
    {
        public class FriendViewModel
        {
            public ObservableCollection<Friend> FriendList 
            { get; set; }
            public void AddFriends()
            {
                FriendList = new ObservableCollection<Friend>();
                FriendList.Add(new Friend() { Name = "Arpan" });
                FriendList.Add(new Friend() { Name = "Nrup" });
                FriendList.Add(new Friend() { Name = "Deba" });
            }
        }
        public class Friend
        {
            public string Name { get; set; }
        }
    }
