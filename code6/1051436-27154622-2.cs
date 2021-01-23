    public abstract class BaseClass<TView, TEnum> 
        where TView: ViewModelBase
        where TEnum : struct,  IComparable, IFormattable, IConvertible
    {
        
        public abstract void RefreshDisplay<TView, TEnum>(TEnum value);
    }
