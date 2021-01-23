    public class Locator {       
       static Locator() {
        Container = new GameContainer();
       }
       public static readonly DependencyProperty ContainerProperty = 
           DependencyProperty.Register("Container", typeof(GameContainer), typeof(Locator));
       public static GameContainer Container {
         get {
             return (GameConainer) new Locator().GetValue(ContainerProperty);
         }
         set {
            new Locator().SetValue(ContainerProperty, value);
         }
       }
    }
    
