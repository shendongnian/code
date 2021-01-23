    public class Concrete3 : BaseClass
    {
    
        public override List<Something> GetSomethings()
        {
        //actual logic here
        }
    
        //override any other abstract methods
        //For some reason this class doesn't want all somethings, so it overrides
        // the base method and filters before calling the base method
        public override AddSomethings(List<Something> addList)
        {
            base.AddSomethings(addList.Where(s => s.Condition == false));
        }
    }
