    public class Criteria
    {
        public Criteria()
        {
            Values = new ObservableCollection<Criterion>();
        }
        public ObservableCollection<Criterion> Values { get; set; }
        public Criterion this[int index]
        {
            get
            {
                return Values.OrderBy(i=>i.Field.Position).ElementAt(index);
            }
            set
            {
                Criterion c = Values.OrderBy(i => i.Field.Position).ElementAt(index);
                c= value;
            }
        }
    }
