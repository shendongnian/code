    public interface IMunger<TConstraint>
    {
        void Munge<T>(ref T it) where T : TConstraint;
    }
    public class Cloner : IMunger<ICloneable>
    {
        public void Munge<T>(ref T it) where T : ICloneable
        {
            if (typeof(T).IsValueType) // See text
                return;
            it = (T)(it.Clone());
        }
    }
