    public abstract class Settings
    {
    
    }
    
    public class AirstrikeSettings : Settings
    {
    
    }
    
    public class MineSettings : Settings
    {
    
    }
    
    public class LauncherSettings : Settings
    {
    
    }
    
    public class Weapon
    {
        public Settings Settings { get; set; } // as this member is public, it can be declared as property
    }
