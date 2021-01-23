    interface IFruit {
        public int c { get; set; }
    }
    
    class Apple : IFruit { }
    class Peach : IFruit { }
    class Lemon : IFruit { }
    
    class Basket {
        List<IFruit> fruitList = new List<IFruit>();
    
        public void AddIFruit<T>(int c) 
            where T : IFruit, new {
    
            var f = new T();
            f.c = c;
            fruitList.Add(f);
        }
    }
