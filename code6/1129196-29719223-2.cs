    public class Profile
    {
        public Profile(int id)
        {
            Age = GetAgeFromSomewhere(id);
        }
        public int Age { get; private set; }
        public int IsLegal { get { return Age > 18; } }
    }
