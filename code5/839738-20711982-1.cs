    public class Animals
    {
        public Animals()
        {
            myModifiableDogList = new List<Dog>();
            Dogs = new ReadOnlyCollection<Dog>(myModifiableDogList);
        }
        private IList<Dog> myModifiableDogList;
        public ReadOnlyCollection<Dog> Dogs { get; private set; }
    }
