    public enum EMilitaryUnits
    {
        Cavalry,
        CanonFodder,
        // ... others
    };
    public interface IMilitaryUnit 
    {
        // rest
    }
    public class Cavalry : IMilitaryUnit 
    {
        public Cavalry() {}
        // ... rest
    }
    public class CannonFodder : IMilitaryUnit 
    {
        public CannonFodder() {}
        // ... rest
    }
    public static MilitaryUnitFactory
    {
        private static readonly Dictionary<EMilitaryUnits, Func<IMilitaryUnit>> map = new {
            { EMilitaryUnits.Cavalry, () => new Cavalry() },
            { EMilitaryUnits.CanonFodder, () => new CanonFodder() },
            // more for the others
        }
        public static IMilitaryUnit Create(EMilitaryUnits kind)
        {
            return map[kind]();
        }
    }
