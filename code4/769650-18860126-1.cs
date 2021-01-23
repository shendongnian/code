    class SingletonClass
    {
        public IFilterBuilder FilterBuilder
        {
            get 
            { 
                return IoC.Container.Resolve<IFilterBuilder>();
            }
        }
    }
