    public class Navigation
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        ObservableCollection<Navigation> Children { get; set; }
     //  public virtual decimal? Amount
     //   {
     //       get { return null; }
     //       set { value = null; }
     //   }
    }
    public class C1 : Navigation { }
    public class C2 : Navigation { }
    public class C3 : Navigation
    {
        private decimal _amount;
        public virtual decimal? Amount
        {
            get { return _amount; }
            set { if (value != null) _amount = (decimal)value; }
        }
    }
    public class C4 : C3
    {
        private decimal _amount;
        public override decimal? Amount
        {
            get { return _amount; }
            set { if (value != null) _amount = (decimal)value; }
        }
    }
