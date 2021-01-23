    public CityViewModel SelectedCity
        {
            get
            {
                return (CityViewModel)GetValue(SelectedCityProperty);
            }
            set
            {
                SetCurrentValue(SelectedCityProperty, value);
            }
        }
