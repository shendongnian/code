    class Factorable<T> where T: class, new() 
    {
        delegate T CreateDelegate();
        CreateDelegate DoCreate = new CreateDelegate (CreateSelf);
        T CreateSelf()
        {
            return new T();
        }
    }
    class Animal : Factorable<Animal>...
    ...
    Factory genesis = new Factory();
    genesis.CreateAnimal = (new Animal()).DoCreate;
    Animal instance = genesis.CreateAnimal(); 
    
    genesis.CreateAnimal = (new Bird()).DoCreate;
    instance = genesis.CreateAnimal();
