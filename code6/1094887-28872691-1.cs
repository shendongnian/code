     public partial class SecondPage : PhoneApplicationPage
        {
            public SecondPage()
            {
                InitializeComponent();
    
                List<Countries> objCountries = new List<Countries>()
    			{
    				new Countries() { Country = "India",  states = new List<States>
    				{
    					new States() { State = "Karnataka" , cities = new List<Cities>
                        {
                            new Cities(){ City = "Bangalore", areas = new List<Areas>
                            {
                                 new Areas(){Area="RamamurthyNagar"},
                                 new Areas(){Area="VasanthNagar"},
                                 new Areas(){Area="RamamurthyNagar"}}                        
                            },
                        
                        }},
    					new States() { State = "TamilNadu", cities = new List<Cities>
                        {
                            new Cities(){ City = "Coimbatore", areas=null}}                    
                        },					
    				}},
                    new Countries() { Country = "Canada",  states = new List<States>
    				{
    					new States() { State = "BritishColombia" , cities = new List<Cities>
                        {
                            new Cities(){ City = "Vancouver" , areas = null}}
                        
                        },
    					new States() { State = "Ontario", cities = new List<Cities>
                        {
                            new Cities(){ City = "Toronto", areas =null}}                    
                        },					
    				}},
    
    					 new Countries() { Country = "UnitedStates",  states = new List<States>
    				{
    					new States() { State = "NewHampshire" , cities = new List<Cities>
                        {
                            new Cities(){ City = "Dover", areas= null}}
                        
                        },
    					new States() { State = "NewJersy", cities = new List<Cities>
                        {
                            new Cities(){ City = "Jersycity", areas=null}}                    
                        },					
    				}},
    							
    			};
    
                this.listCountries.ItemsSource = objCountries;
            }
    
        }
    
        public class Countries : INotifyPropertyChanged
        {
            private bool isExpanded1;
            public string Country { get; set; }
            public IList<States> states { get; set; }
            public bool IsExpanded1
            {
                get
                {
                    return this.isExpanded1;
                }
                set
                {
                    if (this.isExpanded1 != value)
                    {
                        this.isExpanded1 = value;
                        this.OnPropertyChanged("IsExpanded");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class States : INotifyPropertyChanged
        {
            public string State { get; set; }
            public IList<Cities> cities { get; set; }
    
            private bool isExpanded2;
            public bool IsExpanded2
            {
                get
                {
                    return this.isExpanded2;
                }
                set
                {
                    if (this.isExpanded2 != value)
                    {
                        this.isExpanded2 = value;
                        this.OnPropertyChanged("IsExpanded");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class Cities : INotifyPropertyChanged
        {
            public string City { get; set; }
            public IList<Areas> areas { get; set; }
    
            private bool isExpanded3;
            public bool IsExpanded3
            {
                get
                {
                    return this.isExpanded3;
                }
                set
                {
                    if (this.isExpanded3 != value)
                    {
                        this.isExpanded3 = value;
                        this.OnPropertyChanged("IsExpanded");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
        }
    
    
    
        public class Areas
        {
            public string Area { get; set; }
        }
