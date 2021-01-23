    [DataContract]
    public class Userdata
    {
        public Userdata(int id, string name, string surname, string number, string mobile, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Number = number;
            this.Mobile = mobile;
            this.Email = email;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; } 
        [DataMember]      
        public string Surname { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public string Mobile{ get; set; } 
        [DataMember]      
        public string Email{ get; set; }
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
                    userList.Add(new Userdata(user.id, user.name, user.surname, user.number, user.mobile, user.email));
                }
            }
            return userList;
        }
