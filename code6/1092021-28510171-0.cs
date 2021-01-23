    }
    public class Submarine : Toy
    {
    }
    public class Airwolf : Toy
    {
        public Boolean ActivateMissiles()
        {
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Toy> myToys = new List<Toy>();
            myToys.Add(new Submarine());
            myToys.Add(new Airwolf());
            // Looking for airwolves
            foreach (Toy t in myToys)
            {
                if (t is Airwolf)
                {
                    Airwolf myWolf = (Airwolf)t;
                    myWolf.ActivateMissiles();
                }
            }
        }
    }
