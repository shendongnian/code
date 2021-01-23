    public class Person : ObservableObject
    {
        private Person()
        {
            Children = new ObservableCollection<Person>();
        }
        public Person Mother { get; private set; }
        public Person Father { get; private set; }
        public ObservableCollection<Person> Children { get; private set; }
        public Person Procreate(Person father)
        {
            var child = new Person();
            child.Mother = this;
            child.Father = father;
            this.Children.Add(child);
            father.Children.Add(child);
            return child;
        }
    }
