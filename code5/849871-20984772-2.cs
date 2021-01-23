    // Second approach
    abstract class Disk    //base class
    {
        protected void CreateRMA(Disk newDisk)
        {
            ...other initialization code...
        }
        public abstract Disk RMA();    //not sure if this works
    }
    
    class HDD: Disk
    {
        public override HDD RMA()
        {
            return CreateRMA(new RMAService.Exchange(this));
        }
    }
    
    class SSD: Disk
    {
        public override SSD RMA()
        {
            return CreateRMA(new RMAService.Exchange(this));
        }
    }
