    public abstract class Environment<T> where T : Environment<T> {
       
       private List<Animal> animalList;
       private static T s_instance;
       public static T Instance {
          get {
             return (T)s_instance
          }
       }
       
       public void ToCallInConstructor () {
          PopulateTheList ();
          if (Animal.Instance == null) {
             Instantiate (animalList.Get (defaultAnimal)); // pseudocode
          }
       }
       public int CommonMethod () {
          return 1;
       }
       
       public abstract void PopulateTheList();
    }
