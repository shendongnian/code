    public class Person : ObservableObject
    {
        private Person()
        {
            Children = new ObservableCollection<Person>();
        }
        public Person Mother { get; private set; }
        public ObservableCollection<Person> Children { get; private set; }
        public Person Procreate()
        {
            var child = new Person();
            child.Mother = this;
            this.Children.Add(child);
            return child;
        }
    }
