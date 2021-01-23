    public class FilterBuilderProxy : IFilterBuilder
    {
        private Func<IFilterBuilder> factory;
        public FilterBuilderProxy(Func<IFilterBuilder> factory) 
        { 
            this.factory = factory; 
        }
        AddFilter1() { this.factory.Invoke().AddFilter1(); }
        AddFilter2() { this.factory.Invoke().AddFilter2(); }
        // etc
    }
