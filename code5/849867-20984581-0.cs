    abstract class Disk
    {
        public Disk() { }
    }
    public class Disk_Extension_Methods
    {  
        public T RMA<T>(this T oldDisk) where T : Disk
        {
            T newDisk = RMAService.Exchange(oldDisk)
            return newDisk;
        }
    }
