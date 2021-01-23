    public class Factory
    {
        public IList<Measure> ConvertToMeasures(ILoad load)
        {
            if (load == null)
                throw new NullArgumentException("load");
            if (load is A)
                 return ConvertToMeausre((A)load);
            if (load is B)
                 return ConvertToMeausre((B)load);
            throw new NotSupportedException();
        }
        public List<Measure> ConvertToMeausre(A model)
        {
           return some List<Measure>
        }
        public List<Measure> ConvertToMeausre(B model)
        {
            return some List<Measure>
        }
    }
