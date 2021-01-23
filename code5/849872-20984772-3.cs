    abstract class Disk    //base class
    {
        protected Disk CreateRMA()
        {
            Disk  newDisk;
            newDisk = new RMAService.Exchange(this);
            ...whatever else needs to be done...
            return newDisk;
        }
    }
    
    class HDD: Disk
    {
        public HDD RMA()
        {
            return CreateRMA();
        }
    }
    
    class SSD: Disk
    {
        public SSD RMA()
        {
            return CreateRMA();
        }
    }
