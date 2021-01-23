    public abstract class State<out T> where T : Unit
    {
       protected T unit;
       public abstract void Handle();
    }
    public class Engaging : State<Troop> {
      public void Handle() {
        unit.troopMethod();
    }
