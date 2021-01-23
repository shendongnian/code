    public class UnitOfWork
    {
        private Repository<Foo> foos;
        public Repository<Foo> Foos
        {
            get
            {
                if(foos == null)
                    foos = new Repository<Foo>();
                return foos;
            }
        }
    }
