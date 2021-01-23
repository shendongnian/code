    // base strategy, can also be an abstract class if you want to share 
    logic between the settings
    public interface IWeaponSettings 
    {
        // Definition of common structure for the behaviors
        void BehaveInSpecialWay();
        // ...
    }
    
    public class AirstrikeSettings: IWeaponSettings
    {
        // Implementation for Airstrike
        public void BehaveInSpecialWay()
        {
            // Airstrike
        }
    }
    
    public class MineSettings : IWeaponSettings
    {
        // Implementation for Mining
        public void BehaveInSpecialWay()
        {
            // Mining
        }
    }
    
    // ...
    
    public class Weapon
    {
        // Constructor that takes the initial settings as an input
        public Weapon(IWeaponSettings settings)
        {
            Settings = settings
        }
        
        // Public property that can be used to change behavior. 
        // You might want to check against null in the setter
        public IWeaponSettings Settings { get; set; }
    
        public void DoSomething()
        {
            Settings.BehaveInSpecialWay();
        }
    }
