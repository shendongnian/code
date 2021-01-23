    // just for reference: MVVM Light base view model class is used
    public class AddModifyWindroseDialogViewModel : ViewModelBase
    {
        #region Fields
    
        // holds the actual model class
        private Windrose _wr;
        // holds an ObservableCollection for each combination of StabilityLevel & WindspeedClass
        private ObservableCollection<WindroseWindDirection>[][] _dataGrid;
        // for Combobox
        private ObservableCollection<int> _numberOfDirectionValues = new ObservableCollection<int>(Constants.WindroseAllowedNumberOfDirections);    
    
        #endregion
        
            #region Construction
    
            public AddModifyWindroseDialogViewModel(Windrose windrose)
            {            
                _wr = windrose;            
    
                // create array[][] of observable collections, one for each stability <-> windspeed pair
                _dataGrid = new ObservableCollection<WindroseWindDirection>[Enum.GetNames(typeof(StabilityLevel)).Length][];
                int step = 360 / NumberOfDirections;
                foreach (StabilityLevel stability ... )
                {
                    _dataGrid[(int) stability] = new ObservableCollection<WindroseWindDirection>[Enum.GetNames(typeof(WindspeedClass)).Length];
                    foreach (WindspeedClass windspeed ... )
                    {
                        _dataGrid[(int)stability][(int)windspeed] = new ObservableCollection<WindroseWindDirection>();
                        // Add 'No wind' special first row
                        _dataGrid[(int)stability][(int)windspeed].Add(new WindroseWindDirection("No wind", _wr[stability, windspeed, 0]));
                        // Add the rest
                        for (int i = 0; i < NumberOfDirections; i++)
                        {
                            _dataGrid[(int)stability][(int)windspeed].Add(new WindroseWindDirection(String.Format("{0} degrees", i * step), _wr[stability, windspeed, i + 1]));
                        }
                    }
                }
            }
    
            #endregion
            
            #region Properties
    
            public String Name
            {
                get
                {
                    return _wr.Name;
                }
                set
                {
                    if (String.Equals(_wr.Name, value) == false)
                    {
                        _wr.Name = value;
                        RaisePropertyChanged("Name");
                    }
                }
            }
            
            public int NumberOfDirections
            {
                get
                {
                    return _wr.NumberOfDirections;
                }
                set
                {
                    if (_wr.NumberOfDirections != value)
                    {
                        _wr.NumberOfDirections = value;
                        RaisePropertyChanged("NumberOfDirections");
                        UpdateFilteredItems();
                    }
                }
            }        
            public ObservableCollection<int> NumberOfDirectionsValues
            {
                get
                {
                    return _numberOfDirectionValues;
                }
            }
            public StabilityLevel StabilityLevel
            {
                get
                {
                    return _wr.StabilityLevel;
                }
                set
                {
                    if (Enum.Equals(_wr.StabilityLevel, value) == false)
                    {
                        _wr.StabilityLevel = value;
                        RaisePropertyChanged("StabilityLevel");
                        RaisePropertyChanged("FilteredItems");
                        RaisePropertyChanged("WindSpeedAverageClass1");
                        RaisePropertyChanged("WindSpeedAverageClass2");
                        RaisePropertyChanged("WindSpeedAverageClass3");                                        
                    }
                }
            }
            public WindspeedClass Windspeed
            {
                get
                {
                    return _wr.Windspeed;
                }
                set
                {
                    if (Enum.Equals(_wr.Windspeed, value) == false)
                    {
                        _wr.Windspeed = value;
                        RaisePropertyChanged("Windspeed");
                        RaisePropertyChanged("FilteredItems");
                    }
                }
            }
            public ObservableCollection<WindroseWindDirection> FilteredItems
            {
                get
                {
                    return _dataGrid[(int) StabilityLevel][(int) Windspeed];
                }
            }
            public float WindSpeedAverageClass1
            {
                get
                {
                    return _wr[StabilityLevel, WindspeedClass.Class1];
                }
                set
                {
                    if (_wr[StabilityLevel, WindspeedClass.Class1] != value)
                    {
                        _wr[StabilityLevel, WindspeedClass.Class1] = value;
                        RaisePropertyChanged("WindSpeedAverageClass1");
                    }
                }
            }        
            public float WindSpeedAverageClass2
            {
                get
                {
                    return _wr[StabilityLevel, WindspeedClass.Class2];
                }
                set
                {
                    if (_wr[StabilityLevel, WindspeedClass.Class2] != value)
                    {
                        _wr[StabilityLevel, WindspeedClass.Class2] = value;
                        RaisePropertyChanged("WindSpeedAverageClass2");
                    }
                }
            }
            public float WindSpeedAverageClass3
            {
                get
                {
                    return _wr[StabilityLevel, WindspeedClass.Class3];
                }
                set
                {
                    if (_wr[StabilityLevel, WindspeedClass.Class3] != value)
                    {
                        _wr[StabilityLevel, WindspeedClass.Class3] = value;
                        RaisePropertyChanged("WindSpeedAverageClass3");
                    }
                }
            }        
            
            #endregion
            
            private void UpdateFilteredItems()
            {
                /**/
                int step = 360 / NumberOfDirections;
                foreach (StabilityLevel stability ... )
                {                
                    foreach (WindspeedClass windspeed ... )
                    {
                        // Clear the old values
                        _dataGrid[(int)stability][(int)windspeed].Clear();                    
                        // Add 'No wind' special value
                        _dataGrid[(int)stability][(int)windspeed].Add(new WindroseWindDirection("No wind", _wr[stability, windspeed, 0]));
                        // Add degrees
                        for (int i = 0; i < NumberOfDirections; i++)
                        {
                            _dataGrid[(int)stability][(int)windspeed].Add(new WindroseWindDirection(String.Format("{0} degrees", i * step), _wr[stability, windspeed, i + 1]));
                        }
                    }
                }
                RaisePropertyChanged("FilteredItems");
            }                                            
    
    }
