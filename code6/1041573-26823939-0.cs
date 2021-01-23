    [DataContract]
    public class Userdata
    {
        public Userdata(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }       
    }
    public List<Userdata> getUsers()
        {
            var userList = new List<Userdata>();
            using (var db = new Database())
            {
                var query = from x in db.userList
                            orderby x.UserID
                            select x;
                foreach (var user in query)
                {
                    userList.Add(new Userdata(user.id, user.name));
                }
            }
            return userList;
        }
