    public class TypeSwitch<T, TResult>
    {
        bool matched;
        T value;
        TResult result;
        public TypeSwitch(T value)
        {
            this.value = value;
        }
        public TypeSwitch<T, TResult> ForType<TSpecific>(Func<TSpecific, TResult> caseFunc) where TSpecific : T
        {
            if (value is TSpecific)
            {
                matched = true;
                result = caseFunc((TSpecific)value);
            }
            return this;
        }
        public TResult GetValue()
        {
            if (!matched)
            {
                throw new InvalidCastException("No case matched");
            }
            return result;
        }
    }
