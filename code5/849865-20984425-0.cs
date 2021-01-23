    abstract class Disk<T> where T : Disk<T>
    {
        public Disk()
        {
            if( this.GetType() != typeof(T) )
                throw new Exception("The type argument must be precisely the " +
                                    "derived class you're defining. Annoying eh?")
        }
        public T RMA()
        {
            Disk<T> newDisk = RMAService.Exchange(this)
            return (T)newDisk;
        }
    }
