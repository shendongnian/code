    interface IFilter
    {
        bool TestFilter(Person person);
    }
    class CompositeFilter : IFilter
    {
        List<IFilter> _filters = new List<IFilter>();
    
        void AddFilter(IFilter filter)
        {
           _filters.Add(filter);
        }
    
        bool TestFilter(Person person)
        {
            foreach(IFilter filter in _filters)
            {
                if(!filter.TestFilter(person))
                {
                    return false;
                }
            }
        
            return true;
        }
    }
    class CountryFilter : IFilter
    {
        Cuntry Country { get; set; }
    
        bool TestFilter(Person person)
        {
            return person.Country = this.Country;
        }
    }
