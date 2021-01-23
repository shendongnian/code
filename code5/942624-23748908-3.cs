    public class VisibilitiesClass : ICustomTypeProvider, INotifyPropertyChanged
    {
        public Visibility[] Visibilities { get; private set; };
        public VisibilitiesClass(int count) 
        {
            Visibilities = new Visibility[count];
            for (int i = 0; i < count; i++)
                Visibilities[i] = Visibility.Collapsed;
        }
        public Type GetCustomType()
        {
            return new VisibilitiesType(Visibilities.Length);
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
