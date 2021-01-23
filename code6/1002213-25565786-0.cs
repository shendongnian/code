     ObservableCollection<User> users = new ObservableCollection<User>();
            for (int i = 0; i < 5; i++)
            {
                User uo = new User();
                uo.ID = i;
                uo.Name = i.ToString();
                users.Add(uo);
               
    
            }
            List<User> reversed = getResult(users);
            ObservableCollection<User> result = new ObservableCollection<User>(reversed);
        }
    
        private List<User> getResult(ObservableCollection<User> res)
        {
            List<User> result = res.ToList();
            result.Reverse();
            return result;
        }
        public class User
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
