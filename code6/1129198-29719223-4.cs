    public class Profile
    {
        public Profile(int id)
        {
           // C# captures the `id` in a closure.
            _lazyAge = new Lazy<int>(
                () => GetAgeFromSomewhere(id)
            );
        }
        private Lazy<int> _lazyAge;
        public int Age { get { return _lazyAge.Value; } }
        public int IsLegal { get { return Age > 18; } }
    }
