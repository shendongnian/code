    [ContractClass(typeof(CloneableContract<>))]
    public interface ICloneable<out T>
    {
        T Clone();
    }
    [ContractClassFor(typeof(ICloneable<>))]
    internal abstract class CloneableContract<T>: ICloneable<T>
    {
        public T Clone()
        {
            Contract.Ensures(Contract.Result<object>() != null);
            Contract.Ensures(Contract.Result<object>().GetType() == this.GetType());
            return default(T);
        }
    }
