    public abstract class Animal {
       public static Animal Instance { get; private set; }
       
       public Animal () {
          Instance = this;
       }
		public static T GetInstance<T>() where T : Animal {
           return (T)Instance;
		}
    }
