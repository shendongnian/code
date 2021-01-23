    public class Locator {       
       static Locator() {
        Container = new GameContainer();
       }
       public static event EventHandler GameContainerChanged;
       static GameContainer container;
       public static GameContainer Container {
         get { return container;}
         set {
            if(container != value){
              container = value;
              var handler = GameContainerChanged;
              handler(null, EventArgs.Empty);
            }
         }
       }       
    }
    
