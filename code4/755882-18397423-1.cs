    private readonly T _box;
    public Module(T box)
        {
           _box = box;
        }
    
    U[] IModule<T, U>.GetItems(int id )
        {
           return _box.Unboxing(); // I don't know what you plan to do with id
        }
