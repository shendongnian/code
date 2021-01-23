    public class Component : ModelBase
    {}
    public class MedicineComposition : ModelBase
    {
        private IEnumerable<Component> _component;
        public IEnumerable<Component> Components
        {
            get { return _component; }
            set { _component = value; OnPropertyChanged(); }
        }
    }
    public class Item : ModelBase
    {
        private IEnumerable<MedicineComposition> _medicineCompositions;
        public IEnumerable<MedicineComposition> MedicineCompositions
        {
            get { return _medicineCompositions; }
            set { _medicineCompositions = value; OnPropertyChanged(); }
        }
    }
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _id;
        private string _name;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
