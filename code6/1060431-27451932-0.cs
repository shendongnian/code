    public interface IRule
    {
        void Apply(ILocation loc);
    }
    public class World : ILocation
    {
        public List<IRule> Rules { get; set; }
        public void ApplyAllRules()
        {
            foreach (var rule in Rules)
            {
               //This is the part that I don't feel good about.
               rule.Apply(this);
            }
         }
     }
