    [System.Xml.Serialization.XmlRoot("UserData")]
    public class UserData : IEnumerable<User>
    {
        [XmlArray("Users")]
        [XmlArrayItem("User", typeof(User))]
        public User[] Users { get; set; }
        // IEnumerable Member
        public IEnumerator GetEnumerator()
        {
            return this.Users.GetEnumerator();
        }
        IEnumerator<User> IEnumerable<User>.GetEnumerator()
        {
            return ((IEnumerable<User>)this.Users).GetEnumerator();
        }
    }
