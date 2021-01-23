    public class Fish
    {
        public string Species { get; set; }
        public int Age { get; set; }
        private static System.Collections.Concurrent.ConcurrentBag<Fish> Aquarium = new System.Collections.Concurrent.ConcurrentBag<Fish>();
        static Fish()
        {
            var goldFish = new Fish { Age = 1, Species = "Gold Fish" };
            PutFishIntoAquarium(goldFish);
        }
        public static void PutFishIntoAquarium(Fish fish)
        {
            Aquarium.Add(fish);
        }
        public static void ClearAquarium()
        {
            Fish someFish;
            while (!Aquarium.IsEmpty)
            {
                TryTakeFishOutOfAquarium(out someFish);
            }
        }
        public static bool TryTakeFishOutOfAquarium(out Fish fish)
        {
            if (Aquarium.TryTake(out fish))
                return true;
            return false;
        }
        public static bool TryLookAtSomeFish(out Fish fish)
        {
            if (Aquarium.TryPeek(out fish))
                return true;
            return false;
        }
    }
