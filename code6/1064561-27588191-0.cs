    public interface ITrait
    {
        string DoSomething();
    }
    public class Trait<T> where T : ITrait, new()
    {
        public string DoSomething()
        {
            ITrait trait = new T();
            return trait.DoSomething();
        }
    }
    public class TraitUser : ITrait
    {
        public string DoThing()
        {
            return "return something";
        }
    }
    public class TrairInspector
    {
        public void DoThing()
        {
            Trait<TraitUser> traitUser = new Trait<TraitUser>();
            traitUser.DoSomething();
        }
    }
