    public class VisibilitiesClass : ICustomTypeProvider, INotifyPropertyChanged
    {
        public Visibility[] Visibilities { get; private set; };
        public VisibilitiesCustomType(int count) 
        {
            Visibilities = new Visibility[count];
        }
        public Type GetCustomType()
        {
            return new VisibilitiesType(_visibilities.Length);
        }
        public Visibility this[int index]
        {
            get { return Visibilities[index]; }
            set
            {
                Visibilities[index] = value;
                RaisePropertyChanged("V" + index);
            }
        }
    }
