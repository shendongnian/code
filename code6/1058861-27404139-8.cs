    public class Person : ObservableObject
    {
        private Person(Sex gender, Person mother, Person father)
        {
            // TODO: Check for null mother and father
            this.Gender = gender;
            this.Mother = mother;
            this.Father = father;
            Children = new ObservableCollection<Person>();
        }
        public Sex Gender { get; private set; }
        public Person Mother { get; private set; }
        public Person Father { get; private set; }
        public ObservableCollection<Person> Children { get; private set; }
        public Person Procreate(Person father)
        {
            // TODO: Check for null father, confirm gender of father
            var child = new Person(PickRandomGender(), this, father);
            this.Children.Add(child);
            father.Children.Add(child);
            return child;
        }
        private Sex PickRandomGender() { /.../ }
        public enum Sex
        {
            Female,
            Male
        }
    }
