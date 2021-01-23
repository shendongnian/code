    class Lemon : Fruit
    {
        public Lemon(int c = 0) : base(c){}
        //....
    }
    class Apple : Fruit
    {
        public Apple (int c = 0) : base(c){}
        //....
    }
    class Peach : Fruit
    {
        public Peach (int c = 0) : base(c){}
        //....
    }
    
    class Fruit
    {
        public int color;
        public Fruit(int c){ color = c; }
    }
    
    class Basket
    {
        List<Fruit> fruits = new List<Fruit>();
        public void AddFruit(Fruit f)
        {
            fruits.Add(f);
        }
        public void CreateFruit<T>(int c) : where T : Fruit
        {
            Fruit f = Activator.CreateInstance<T>() as Fruit;
            f.color = c;
            fruits.Add(f);
        }
    }
