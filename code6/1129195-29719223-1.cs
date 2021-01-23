    public class Profile
    {
        private readonly int _id;
        public Profile(int id)
        {
            _id = id;
        }
        private int? _age;
        public int Age {
            get {
                if (_age == null) {
                    _age = GetAgeFromSomewhere(_id);
                }
                return _age.Value;
            }
        }
        public int IsLegal { get { return Age > 18; } }
    }
