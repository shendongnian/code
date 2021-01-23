    public class CommonWork<T> 
      where T: BaseClass,
               new T()// <- probably you'll need it to create instances of T
     
      public T CommonWork(){
        T result = new T();
        ...
        return T;
      }
    }
    ...
    Commonwork<Derived2> common = new Commonwork<Derived2>();
    BaseClass result = common.CommonWork();
