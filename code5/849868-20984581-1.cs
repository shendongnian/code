    public abstract class Disk
    {
        public Disk() { }
    }
    public static class Disk_Extension_Methods
    {  
        public static T RMA<T>(this T oldDisk) where T : Disk
        {
            T newDisk = RMAService.Exchange(oldDisk)
            return newDisk;
        }
    }
