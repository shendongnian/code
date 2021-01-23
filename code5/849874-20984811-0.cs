    abstract class Disk<T> where T : Disk<T> {
        protected Disk()
        {
        }
        public T RMA()
        {
            return RMAService.Exchange((dynamic)this);
        }
    }
