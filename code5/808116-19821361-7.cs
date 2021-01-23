    public class Locator {       
       static Locator() {
        Container = new GameContainer();
       }
       public static event EventHandler ContainerChanged;
       static GameContainer container;
       public static GameContainer Container {
         get { return container;}
         set {
            if(container != value){
              container = value;
              var handler = ContainerChanged;
              handler(null, EventArgs.Empty);
            }
         }
       }       
    }
    
