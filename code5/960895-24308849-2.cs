    public partial class ucTreeView : ucBaseClass
    {
        public ObservableCollection<CountryList> country_List{ get; set; }
        public ucTreeView()
        {
                InitializeComponent();
                country_List = new ObservableCollection<CountryList>();
                CountryList cList = new CountryList();
                country_List = cList.getCountries;//retrieve country list
                this.DataContext = this
        }
    }
