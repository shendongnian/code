    class Zoo
        {
            public ObservableCollection<T> GetData<T>() where T : class
            {
            if (typeof(T) == typeof(Cat))
                return new ObservableCollection<T>(this.GetCatCollection().Cast<T>().ToList());
                // or:
                // return new ObservableCollection<T>(Cat.GetDefaultCollection().Cast<T>().ToList());
            if (typeof(T) == typeof(Dog))
                return new ObservableCollection<T>(Dog.GetDefaultCollection().Cast<T>().ToList());
            if (typeof(T) == typeof(Lion))
                return new ObservableCollection<T>(Lion.GetDefaultCollection().Cast<T>().ToList());
            return null;
            // pseudo-switch version
            //ObservableCollection<T> result = null;
            //var @switch = new Dictionary<Type, Action> {
            //{ typeof(Cat), () => result = new ObservableCollection<T>(Cat.GetDefaultCollection().Cast<T>().ToList()) },
            //{ typeof(Dog), () => result =  new ObservableCollection<T>(Dog.GetDefaultCollection().Cast<T>().ToList())},
            //{ typeof(Lion), () => result = new ObservableCollection<T>(Lion.GetDefaultCollection().Cast<T>().ToList())}};
            //@switch[typeof(T)]();
            //return result;
        }
     
        private ObservableCollection<Cat> GetCatCollection()
        {
                ObservableCollection<Cat> list = new ObservableCollection<Cat>();
                list.Add(new Cat { CatName = "Cat No. 1" });
                list.Add(new Cat { CatName = "Cat No. 2" });
                list.Add(new Cat { CatName = "Cat No. 3" });
                return list;
        }
    }
    class Cat
    {
        public string CatName { get; set; }
        public static ObservableCollection<Cat> GetDefaultCollection()
        {
            ObservableCollection<Cat> list = new ObservableCollection<Cat>();
            list.Add(new Cat { CatName = "Cat No. 1" });
            list.Add(new Cat { CatName = "Cat No. 2" });
            list.Add(new Cat { CatName = "Cat No. 3" });
            return list;
        }
    }
    class Dog
    {
        public string DogName { get; set; }
        public static ObservableCollection<Dog> GetDefaultCollection()
        {
            ObservableCollection<Dog> list = new ObservableCollection<Dog>();
            list.Add(new Dog { DogName = "Dog No. 1" });
            list.Add(new Dog { DogName = "Dog No. 2" });
            list.Add(new Dog { DogName = "Dog No. 3" });
            return list;
        }
    }
    class Lion
    {
        public string LionName { get; set; }
        public static ObservableCollection<Lion> GetDefaultCollection()
        {
            ObservableCollection<Lion> list = new ObservableCollection<Lion>();
            list.Add(new Lion { LionName = "Lion No. 1" });
            list.Add(new Lion { LionName = "Lion No. 2" });
            list.Add(new Lion { LionName = "Lion No. 3" });
            return list;
        }
    }
