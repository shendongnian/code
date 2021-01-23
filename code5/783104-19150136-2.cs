    public abstract class Derple
    {
        protected virtual void OnAction(string action, object result) { Console.WriteLine("Derple"); }
    }
    public class Herple : Derple
    {
        public void DoTheHerple(string action, object result) { base.OnAction(action, result); }
    }
