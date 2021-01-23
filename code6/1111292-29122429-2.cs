    public class MyDoubleList : IList<double>
    {
        public readonly Collection<dynamic> Base;
        public MyDoubleList(Collection<dynamic> @base)
        {
            Base = @base;
        }
        // Now reimplement all the IList<double> methods by using the 
        // Base collection, like:
        public int IndexOf(double item)
        {
            return Base.IndexOf(item);
        }
        public double this[int index]
        {
            get
            {
                return Base[index];
            }
            set
            {
                Base[index] = value;
            }
        }
        public void Add(double item)
        {
            Base.Add(item);
        }
        // And so on
    }
