    public class BirdCollector<T> where T : Bird
    {
        readonly Dictionary<string, T> nameToBird_;
        public BirdCollector(Dictionary<string, T> nameToBird)
        {
            nameToBird_ = nameToBird;
        }
        public T GetBird(string name)
        {
            T bird;
            if (nameToBird_.TryGetValue(name, out bird))
            {
                return bird;
            }
            // handle error
            return null;
        }
    }
